using Microsoft.Office.Interop.PowerPoint;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace APKSangbundelSamesteller
{
    public partial class APKLiedSamesteller : Form
    {
        public static List<LiedGUI> liedGUIList;

        public APKLiedSamesteller()
        {
            InitializeComponent();
        }



        public static List<string> GetAllValidLines(string inputString)
        {
            return inputString.Split('\n').ToList().Where(s => s.Contains(Defines.Psalm) || s.Contains(Defines.Gesang)
                                                          || s.Contains(Defines.PsalmKort) || s.Contains(Defines.GesangKort)).ToList();
        }

        public static List<LiedData> GetValuesList(List<string> liedData)
        {
            var liedDataList = new List<LiedData>();

            Regex expression = new Regex(@"[0-9a-zA-Z]+: (?<PsGs>[a-zA-Z]+) (?<LiedNommer>\d+):(?<Verse>[ ^0-9,-]+)");//
            Regex variasie = new Regex(@"\((?<Variasie>[ ^0-9a-zA-Zêë]+)\)");//

            foreach (var data in liedData)
            {
                Match match = expression.Match(data);
                Match matchVariasie = variasie.Match(data);
                if (match.Success)
                {
                    // ... Get group by name.
                    string PsGs = match.Groups["PsGs"].Value;

                    if (PsGs == Defines.PsalmKort)
                    {
                        PsGs = Defines.Psalm;
                    }
                    else if (PsGs == Defines.GesangKort)
                    {
                        PsGs = Defines.Gesang;
                    }

                    string LiedNommer = match.Groups["LiedNommer"].Value;
                    string Verse = match.Groups["Verse"].Value;

                    if (string.IsNullOrEmpty(LiedNommer)
                        || string.IsNullOrEmpty(PsGs)
                        || string.IsNullOrEmpty(Verse))
                    {
                        continue;
                    }

                    var variasieText = string.Empty;
                    if (matchVariasie.Success)
                    {
                        variasieText = matchVariasie.Groups["Variasie"].Value;
                    }

                    int.TryParse(LiedNommer, out int nommer); ;
                    var isPsalm = PsGs == Defines.Psalm || PsGs ==Defines.PsalmKort;

                    liedDataList.Add(new LiedData()
                    {
                        IsPsalm = isPsalm,
                        Nommer = nommer,
                        Variasie = variasieText,
                        VerseList = KryVerseList(Verse),
                        liedInfo = GetLiedInfo(PsGs + " " + nommer, variasieText, isPsalm)
                    });
                }
                else 
                {
                    string message = "Die formaat lyk of dit nie reg is nie. Probeer weer :)";
                    MessageBox.Show(message);
                    return null;
                }
            }

            return liedDataList;
        }

        public static LiedInfo GetLiedInfo(string liedNaam, string variasie, bool isPsalm)
        {
            var listOfSongs = Directory.GetDirectories(isPsalm ? Psalms.FullFolderPath : Gesange.FullFolderPath);

            var gesoekdeLiedName = listOfSongs.Where(song => song.Contains(liedNaam) && song.Contains(variasie)).ToList();

            var json = File.ReadAllText(Path.Combine(isPsalm ? Psalms.FullFolderPath : Gesange.FullFolderPath, gesoekdeLiedName[0], "LiedInfo.json"));
            var liedInfo = (LiedInfo)JsonConvert.DeserializeObject(json, typeof(LiedInfo));

            return liedInfo;
        }

        public static List<int> KryVerseList(string VerseString)
        {
            var verseList = new List<int>();

            var stringSplit = VerseString.Split(',');

            foreach (var text in stringSplit)
            {
                if (text.Contains("-"))
                {
                    var newArray = text.Split('-');

                    int.TryParse(newArray[0], out int nommerEen);
                    int.TryParse(newArray[1], out int nommerTwee);

                    for (int count = nommerEen; count <= nommerTwee; count++)
                    {
                        verseList.Add(count);
                    }
                }
                else
                {
                    int.TryParse(text, out int nommer);

                    verseList.Add(nommer);
                }
            }

            return verseList;
        }

        public void CreateSlideShow()
        {
            var voorsang = voorsangTextBox.Text;
            var erediens = erediensTextBox.Text;
            var validLinesVoorsang = GetAllValidLines(voorsang);
            var validLinesErediens = GetAllValidLines(erediens);

            validLinesVoorsang.AddRange(validLinesErediens);

            var liedDataList = GetValuesList(validLinesVoorsang);

            if (liedDataList == null)
            {
                return;
            }

            Microsoft.Office.Interop.PowerPoint.Application pptApplication = new Microsoft.Office.Interop.PowerPoint.Application();

            Slides slides;
            _Slide slide;

            // Create the Presentation File
            Presentation pptPresentation = pptApplication.Presentations.Open(Template.FullPath,
                MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);

            CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutTitleOnly];
            // Create new Slide
            slides = pptPresentation.Slides;

            var count = 2;
            foreach (var liedData in liedDataList)
            {
                var imageList = GetImageNamesList(liedData);

                foreach (var image in imageList)
                {
                    slide = slides.AddSlide(count, customLayout);

                    var path = Path.Combine(liedData.IsPsalm ? Psalms.FullFolderPath : Gesange.FullFolderPath, liedData.liedInfo.LiedNaam, image);
                    slide.Shapes.AddPicture(path, MsoTriState.msoFalse, MsoTriState.msoTrue, 0, 0, pptPresentation.PageSetup.SlideWidth, pptPresentation.PageSetup.SlideHeight);

                    count++;
                }

                slide = slides.AddSlide(count, customLayout);

                slide.Shapes.AddPicture(BlackImage.FullPath, MsoTriState.msoFalse, MsoTriState.msoTrue, 0, 0, pptPresentation.PageSetup.SlideWidth, pptPresentation.PageSetup.SlideHeight);

                count++;
            }

            var date = DateTime.Now;
            // DateTime.DayOfWeek is an enum which evaluates to 0 for Sunday and 6 for Saturday when cast to int.
            var fileName = "Erediens " + date.AddDays((7 - (int)date.DayOfWeek) % 7).ToString("yyyyMMdd") + " " + AandDagComboBox.Text;
            pptPresentation.SaveAs(Path.Combine(AppContext.BaseDirectory, fileName), PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
        }

        public static List<string> GetImageNamesList(LiedData liedData)
        {
            const string slideName = "Slide";
            const string jpegIdentifier = ".jpg";

            var listOfImageNames = new List<string>();

            var verseList = liedData.VerseList;
            var liedInfo = liedData.liedInfo;

            foreach (var vers in verseList)
            {
                if (liedInfo.Tipe == 2)
                {
                    if (vers == 1)
                    {
                        listOfImageNames.Add(slideName + vers + jpegIdentifier);
                        listOfImageNames.Add(slideName + (vers + 1) + jpegIdentifier);
                        listOfImageNames.Add(slideName + (vers + 2) + jpegIdentifier);
                    }
                    else
                    {
                        listOfImageNames.Add(slideName + (vers * 3 - 2) + jpegIdentifier);
                        listOfImageNames.Add(slideName + (vers * 3 - 1) + jpegIdentifier);
                        listOfImageNames.Add(slideName + (vers * 3) + jpegIdentifier);
                    }
                }
                else if (liedInfo.Tipe == 1)
                {
                    if (vers == 1)
                    {
                        listOfImageNames.Add(slideName + vers + jpegIdentifier);
                    }
                    else
                    {
                        listOfImageNames.Add(slideName + (vers * 2 - 1) + jpegIdentifier);
                    }
                    
                    listOfImageNames.Add(slideName + (vers * 2) + jpegIdentifier);
                }
                else
                {
                    listOfImageNames.Add(slideName + vers + jpegIdentifier);
                }
            }

            return listOfImageNames;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateSlideShow();
        }
    }
}
