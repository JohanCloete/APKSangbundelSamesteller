using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKSangbundelSamesteller
{
    public static class FileAndFolders
    {
        public static string CurrentDomain
        {
            get { return AppContext.BaseDirectory; }
        }

        public static string Resources
        {
            get { return Path.Combine(CurrentDomain, "Resources"); }
        }

    }

    public static class Template
    {
        public static string FullPath
        {
            get { return Path.Combine(FileAndFolders.Resources, FilePath); }
        }

        public static string FilePath
        {
            get { return "Sjabloon.pptx"; }
        }
    }

    public static class BlackImage
    {
        public static string FullPath
        {
            get { return Path.Combine(FileAndFolders.Resources, FilePath); }
        }

        public static string FilePath
        {
            get { return "Swart.jpg"; }
        }
    }

    public static class Gesange
    {
        public static string FullFolderPath
        {
            get { return Path.Combine(FileAndFolders.Resources, FilePath); }
        }

        public static string FilePath
        {
            get { return "APK Gesange Junie 2019"; }
        }
    }

    public static class Psalms
    {
        public static string FullFolderPath
        {
            get { return Path.Combine(FileAndFolders.Resources, FilePath); }
        }

        public static string FilePath
        {
            get { return "APK Psalms Junie 2019"; }
        }
    }
}
