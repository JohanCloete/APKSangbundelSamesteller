namespace APKSangbundelSamesteller
{
    partial class APKLiedSamesteller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(APKLiedSamesteller));
            this.Diens = new System.Windows.Forms.Label();
            this.voorsangTextBox = new System.Windows.Forms.TextBox();
            this.Genereer = new System.Windows.Forms.Button();
            this.Voorsang = new System.Windows.Forms.Label();
            this.erediensTextBox = new System.Windows.Forms.TextBox();
            this.AandDagComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Diens
            // 
            this.Diens.AutoSize = true;
            this.Diens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Diens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Diens.Location = new System.Drawing.Point(81, 302);
            this.Diens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Diens.Name = "Diens";
            this.Diens.Size = new System.Drawing.Size(83, 20);
            this.Diens.TabIndex = 19;
            this.Diens.Text = "Erediens";
            // 
            // voorsangTextBox
            // 
            this.voorsangTextBox.Location = new System.Drawing.Point(85, 35);
            this.voorsangTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.voorsangTextBox.Multiline = true;
            this.voorsangTextBox.Name = "voorsangTextBox";
            this.voorsangTextBox.Size = new System.Drawing.Size(304, 233);
            this.voorsangTextBox.TabIndex = 25;
            // 
            // Genereer
            // 
            this.Genereer.Location = new System.Drawing.Point(289, 600);
            this.Genereer.Margin = new System.Windows.Forms.Padding(4);
            this.Genereer.Name = "Genereer";
            this.Genereer.Size = new System.Drawing.Size(100, 28);
            this.Genereer.TabIndex = 0;
            this.Genereer.Text = "Genereer";
            this.Genereer.UseVisualStyleBackColor = true;
            this.Genereer.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Voorsang
            // 
            this.Voorsang.AutoSize = true;
            this.Voorsang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Voorsang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Voorsang.Location = new System.Drawing.Point(81, 11);
            this.Voorsang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Voorsang.Name = "Voorsang";
            this.Voorsang.Size = new System.Drawing.Size(88, 20);
            this.Voorsang.TabIndex = 8;
            this.Voorsang.Text = "Voorsang";
            // 
            // erediensTextBox
            // 
            this.erediensTextBox.Location = new System.Drawing.Point(85, 326);
            this.erediensTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.erediensTextBox.Multiline = true;
            this.erediensTextBox.Name = "erediensTextBox";
            this.erediensTextBox.Size = new System.Drawing.Size(304, 233);
            this.erediensTextBox.TabIndex = 26;
            // 
            // AandDagComboBox
            // 
            this.AandDagComboBox.FormattingEnabled = true;
            this.AandDagComboBox.Items.AddRange(new object[] {
            "Oggend",
            "Aand"});
            this.AandDagComboBox.Location = new System.Drawing.Point(85, 604);
            this.AandDagComboBox.Name = "AandDagComboBox";
            this.AandDagComboBox.Size = new System.Drawing.Size(148, 24);
            this.AandDagComboBox.TabIndex = 27;
            this.AandDagComboBox.Text = "Oggend";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 581);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Oggend of aand:";
            // 
            // APKLiedSamesteller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 654);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AandDagComboBox);
            this.Controls.Add(this.erediensTextBox);
            this.Controls.Add(this.voorsangTextBox);
            this.Controls.Add(this.Diens);
            this.Controls.Add(this.Voorsang);
            this.Controls.Add(this.Genereer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "APKLiedSamesteller";
            this.Text = "APK Lied Samesteller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Diens;
        private System.Windows.Forms.TextBox voorsangTextBox;
        private System.Windows.Forms.Button Genereer;
        private System.Windows.Forms.Label Voorsang;
        private System.Windows.Forms.TextBox erediensTextBox;
        private System.Windows.Forms.ComboBox AandDagComboBox;
        private System.Windows.Forms.Label label1;
    }
}

