
using System.Windows.Forms;

namespace FS22_ModManagerCore
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_GetModFolder = new System.Windows.Forms.Button();
            this.Btn_LockModFolder = new System.Windows.Forms.Button();
            this.Txtbox_ModFolder = new System.Windows.Forms.TextBox();
            this.Btn_LockGameSave = new System.Windows.Forms.Button();
            this.Btn_ReadNow = new System.Windows.Forms.Button();
            this.Selectbox_GameSave = new System.Windows.Forms.ComboBox();
            this.Lst_ModList = new System.Windows.Forms.ListView();
            this.ModRealNameHeader = new System.Windows.Forms.ColumnHeader();
            this.ModFileNameHeader = new System.Windows.Forms.ColumnHeader();
            this.Picbox_ModPicture = new System.Windows.Forms.PictureBox();
            this.Txtbox_ModInfoDisplay = new System.Windows.Forms.TextBox();
            this.GithubLink = new System.Windows.Forms.LinkLabel();
            this.Btn_OpenExplorer = new System.Windows.Forms.Button();
            this.Btn_OpenFile = new System.Windows.Forms.Button();
            this.Gpb_SortingMethod = new System.Windows.Forms.GroupBox();
            this.Rad_ByFileSize = new System.Windows.Forms.RadioButton();
            this.Rad_ByLastModif = new System.Windows.Forms.RadioButton();
            this.Rad_ByFileName = new System.Windows.Forms.RadioButton();
            this.Rad_ByModName = new System.Windows.Forms.RadioButton();
            this.Gpb_Ssquence = new System.Windows.Forms.GroupBox();
            this.Rad_Descending = new System.Windows.Forms.RadioButton();
            this.Rad_Ascending = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Picbox_ModPicture)).BeginInit();
            this.Gpb_SortingMethod.SuspendLayout();
            this.Gpb_Ssquence.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_GetModFolder
            // 
            this.Btn_GetModFolder.Location = new System.Drawing.Point(51, 93);
            this.Btn_GetModFolder.Name = "Btn_GetModFolder";
            this.Btn_GetModFolder.Size = new System.Drawing.Size(120, 40);
            this.Btn_GetModFolder.TabIndex = 0;
            this.Btn_GetModFolder.Text = "Get Mod Folder";
            this.Btn_GetModFolder.UseVisualStyleBackColor = true;
            this.Btn_GetModFolder.Click += new System.EventHandler(this.Btn_GetModFolder_Click);
            // 
            // Btn_LockModFolder
            // 
            this.Btn_LockModFolder.Enabled = false;
            this.Btn_LockModFolder.Location = new System.Drawing.Point(201, 93);
            this.Btn_LockModFolder.Name = "Btn_LockModFolder";
            this.Btn_LockModFolder.Size = new System.Drawing.Size(120, 40);
            this.Btn_LockModFolder.TabIndex = 1;
            this.Btn_LockModFolder.Text = "Lock Mod Folder";
            this.Btn_LockModFolder.UseVisualStyleBackColor = true;
            this.Btn_LockModFolder.Click += new System.EventHandler(this.Btn_LockModFolder_Click);
            // 
            // Txtbox_ModFolder
            // 
            this.Txtbox_ModFolder.Location = new System.Drawing.Point(51, 40);
            this.Txtbox_ModFolder.Name = "Txtbox_ModFolder";
            this.Txtbox_ModFolder.Size = new System.Drawing.Size(270, 23);
            this.Txtbox_ModFolder.TabIndex = 2;
            this.Txtbox_ModFolder.TextChanged += new System.EventHandler(this.Txtbox_ModFolder_TextChanged);
            // 
            // Btn_LockGameSave
            // 
            this.Btn_LockGameSave.Location = new System.Drawing.Point(414, 93);
            this.Btn_LockGameSave.Name = "Btn_LockGameSave";
            this.Btn_LockGameSave.Size = new System.Drawing.Size(120, 40);
            this.Btn_LockGameSave.TabIndex = 4;
            this.Btn_LockGameSave.Text = "Lock Game Save";
            this.Btn_LockGameSave.UseVisualStyleBackColor = true;
            this.Btn_LockGameSave.Click += new System.EventHandler(this.Btn_LockGameSave_Click);
            // 
            // Btn_ReadNow
            // 
            this.Btn_ReadNow.Enabled = false;
            this.Btn_ReadNow.Location = new System.Drawing.Point(564, 93);
            this.Btn_ReadNow.Name = "Btn_ReadNow";
            this.Btn_ReadNow.Size = new System.Drawing.Size(120, 40);
            this.Btn_ReadNow.TabIndex = 3;
            this.Btn_ReadNow.Text = "Read Now";
            this.Btn_ReadNow.UseVisualStyleBackColor = true;
            this.Btn_ReadNow.Click += new System.EventHandler(this.Btn_ReadNow_Click);
            // 
            // Selectbox_GameSave
            // 
            this.Selectbox_GameSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Selectbox_GameSave.Items.AddRange(new object[] {
            " Continue Without GameSave",
            " savegame1",
            " savegame2",
            " savegame3",
            " savegame4",
            " savegame5",
            " savegame6",
            " savegame7",
            " savegame8",
            " savegame9",
            " savegame10",
            " savegame11",
            " savegame12",
            " savegame13",
            " savegame14",
            " savegame15",
            " savegame16",
            " savegame17",
            " savegame18",
            " savegame19",
            " savegame20"});
            this.Selectbox_GameSave.Location = new System.Drawing.Point(414, 38);
            this.Selectbox_GameSave.Name = "Selectbox_GameSave";
            this.Selectbox_GameSave.Size = new System.Drawing.Size(270, 25);
            this.Selectbox_GameSave.TabIndex = 5;
            // 
            // Lst_ModList
            // 
            this.Lst_ModList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModRealNameHeader,
            this.ModFileNameHeader});
            this.Lst_ModList.FullRowSelect = true;
            this.Lst_ModList.GridLines = true;
            this.Lst_ModList.Location = new System.Drawing.Point(760, 135);
            this.Lst_ModList.Name = "Lst_ModList";
            this.Lst_ModList.Size = new System.Drawing.Size(466, 534);
            this.Lst_ModList.TabIndex = 6;
            this.Lst_ModList.UseCompatibleStateImageBehavior = false;
            this.Lst_ModList.View = System.Windows.Forms.View.Details;
            this.Lst_ModList.SelectedIndexChanged += new System.EventHandler(this.Lst_ModList_SelectedIndexChanged);
            // 
            // ModRealNameHeader
            // 
            this.ModRealNameHeader.Text = "Mod Name";
            this.ModRealNameHeader.Width = 223;
            // 
            // ModFileNameHeader
            // 
            this.ModFileNameHeader.Text = "Zip File Name";
            this.ModFileNameHeader.Width = 222;
            // 
            // Picbox_ModPicture
            // 
            this.Picbox_ModPicture.Location = new System.Drawing.Point(51, 246);
            this.Picbox_ModPicture.Name = "Picbox_ModPicture";
            this.Picbox_ModPicture.Size = new System.Drawing.Size(270, 255);
            this.Picbox_ModPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picbox_ModPicture.TabIndex = 7;
            this.Picbox_ModPicture.TabStop = false;
            // 
            // Txtbox_ModInfoDisplay
            // 
            this.Txtbox_ModInfoDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Txtbox_ModInfoDisplay.Location = new System.Drawing.Point(393, 167);
            this.Txtbox_ModInfoDisplay.Multiline = true;
            this.Txtbox_ModInfoDisplay.Name = "Txtbox_ModInfoDisplay";
            this.Txtbox_ModInfoDisplay.ReadOnly = true;
            this.Txtbox_ModInfoDisplay.Size = new System.Drawing.Size(312, 412);
            this.Txtbox_ModInfoDisplay.TabIndex = 8;
            // 
            // GithubLink
            // 
            this.GithubLink.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.GithubLink.AutoSize = true;
            this.GithubLink.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GithubLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.GithubLink.Location = new System.Drawing.Point(25, 579);
            this.GithubLink.Name = "GithubLink";
            this.GithubLink.Size = new System.Drawing.Size(322, 70);
            this.GithubLink.TabIndex = 9;
            this.GithubLink.TabStop = true;
            this.GithubLink.Text = "View on Github for\r\nupdates and bug report";
            this.GithubLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GithubLink.VisitedLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.GithubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GithubLink_LinkClicked);
            // 
            // Btn_OpenExplorer
            // 
            this.Btn_OpenExplorer.Enabled = false;
            this.Btn_OpenExplorer.Location = new System.Drawing.Point(393, 609);
            this.Btn_OpenExplorer.Name = "Btn_OpenExplorer";
            this.Btn_OpenExplorer.Size = new System.Drawing.Size(140, 40);
            this.Btn_OpenExplorer.TabIndex = 11;
            this.Btn_OpenExplorer.Text = "Locate In Explorer";
            this.Btn_OpenExplorer.UseVisualStyleBackColor = true;
            this.Btn_OpenExplorer.Click += new System.EventHandler(this.Btn_OpenExplorer_Click);
            // 
            // Btn_OpenFile
            // 
            this.Btn_OpenFile.Enabled = false;
            this.Btn_OpenFile.Location = new System.Drawing.Point(565, 609);
            this.Btn_OpenFile.Name = "Btn_OpenFile";
            this.Btn_OpenFile.Size = new System.Drawing.Size(140, 40);
            this.Btn_OpenFile.TabIndex = 10;
            this.Btn_OpenFile.Text = "Open Mod Zip File";
            this.Btn_OpenFile.UseVisualStyleBackColor = true;
            this.Btn_OpenFile.Click += new System.EventHandler(this.Btn_OpenFile_Click);
            // 
            // Gpb_SortingMethod
            // 
            this.Gpb_SortingMethod.Controls.Add(this.Rad_ByFileSize);
            this.Gpb_SortingMethod.Controls.Add(this.Rad_ByLastModif);
            this.Gpb_SortingMethod.Controls.Add(this.Rad_ByFileName);
            this.Gpb_SortingMethod.Controls.Add(this.Rad_ByModName);
            this.Gpb_SortingMethod.Location = new System.Drawing.Point(760, 23);
            this.Gpb_SortingMethod.Name = "Gpb_SortingMethod";
            this.Gpb_SortingMethod.Size = new System.Drawing.Size(285, 106);
            this.Gpb_SortingMethod.TabIndex = 12;
            this.Gpb_SortingMethod.TabStop = false;
            this.Gpb_SortingMethod.Text = "Sorting Method";
            // 
            // Rad_ByFileSize
            // 
            this.Rad_ByFileSize.AutoSize = true;
            this.Rad_ByFileSize.Location = new System.Drawing.Point(155, 65);
            this.Rad_ByFileSize.Name = "Rad_ByFileSize";
            this.Rad_ByFileSize.Size = new System.Drawing.Size(90, 21);
            this.Rad_ByFileSize.TabIndex = 0;
            this.Rad_ByFileSize.TabStop = true;
            this.Rad_ByFileSize.Text = "By File Size";
            this.Rad_ByFileSize.UseVisualStyleBackColor = true;
            // 
            // Rad_ByLastModif
            // 
            this.Rad_ByLastModif.AutoSize = true;
            this.Rad_ByLastModif.Location = new System.Drawing.Point(27, 65);
            this.Rad_ByLastModif.Name = "Rad_ByLastModif";
            this.Rad_ByLastModif.Size = new System.Drawing.Size(106, 21);
            this.Rad_ByLastModif.TabIndex = 0;
            this.Rad_ByLastModif.TabStop = true;
            this.Rad_ByLastModif.Text = "By Last Modif";
            this.Rad_ByLastModif.UseVisualStyleBackColor = true;
            // 
            // Rad_ByFileName
            // 
            this.Rad_ByFileName.Location = new System.Drawing.Point(155, 30);
            this.Rad_ByFileName.Name = "Rad_ByFileName";
            this.Rad_ByFileName.Size = new System.Drawing.Size(102, 21);
            this.Rad_ByFileName.TabIndex = 0;
            this.Rad_ByFileName.TabStop = true;
            this.Rad_ByFileName.Text = "By File Name";
            this.Rad_ByFileName.UseVisualStyleBackColor = true;
            // 
            // Rad_ByModName
            // 
            this.Rad_ByModName.AutoSize = true;
            this.Rad_ByModName.Location = new System.Drawing.Point(27, 30);
            this.Rad_ByModName.Name = "Rad_ByModName";
            this.Rad_ByModName.Size = new System.Drawing.Size(111, 21);
            this.Rad_ByModName.TabIndex = 0;
            this.Rad_ByModName.TabStop = true;
            this.Rad_ByModName.Text = "By Mod Name";
            this.Rad_ByModName.UseVisualStyleBackColor = true;
            // 
            // Gpb_Ssquence
            // 
            this.Gpb_Ssquence.Controls.Add(this.Rad_Descending);
            this.Gpb_Ssquence.Controls.Add(this.Rad_Ascending);
            this.Gpb_Ssquence.Location = new System.Drawing.Point(1051, 23);
            this.Gpb_Ssquence.Name = "Gpb_Ssquence";
            this.Gpb_Ssquence.Size = new System.Drawing.Size(175, 106);
            this.Gpb_Ssquence.TabIndex = 13;
            this.Gpb_Ssquence.TabStop = false;
            this.Gpb_Ssquence.Text = "Sequence";
            // 
            // Rad_Descending
            // 
            this.Rad_Descending.AutoSize = true;
            this.Rad_Descending.Location = new System.Drawing.Point(36, 65);
            this.Rad_Descending.Name = "Rad_Descending";
            this.Rad_Descending.Size = new System.Drawing.Size(94, 21);
            this.Rad_Descending.TabIndex = 0;
            this.Rad_Descending.TabStop = true;
            this.Rad_Descending.Text = "Descending";
            this.Rad_Descending.UseVisualStyleBackColor = true;
            // 
            // Rad_Ascending
            // 
            this.Rad_Ascending.AutoSize = true;
            this.Rad_Ascending.Location = new System.Drawing.Point(36, 30);
            this.Rad_Ascending.Name = "Rad_Ascending";
            this.Rad_Ascending.Size = new System.Drawing.Size(86, 21);
            this.Rad_Ascending.TabIndex = 0;
            this.Rad_Ascending.TabStop = true;
            this.Rad_Ascending.Text = "Ascending";
            this.Rad_Ascending.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Gpb_Ssquence);
            this.Controls.Add(this.Gpb_SortingMethod);
            this.Controls.Add(this.Btn_OpenExplorer);
            this.Controls.Add(this.Btn_OpenFile);
            this.Controls.Add(this.GithubLink);
            this.Controls.Add(this.Txtbox_ModInfoDisplay);
            this.Controls.Add(this.Picbox_ModPicture);
            this.Controls.Add(this.Lst_ModList);
            this.Controls.Add(this.Selectbox_GameSave);
            this.Controls.Add(this.Btn_LockGameSave);
            this.Controls.Add(this.Btn_ReadNow);
            this.Controls.Add(this.Txtbox_ModFolder);
            this.Controls.Add(this.Btn_LockModFolder);
            this.Controls.Add(this.Btn_GetModFolder);
            this.Icon = global::FS22_ModManagerCore.Properties.Resources.Logo_Farming_Simulator_22;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FS22 Mod Manager Core";
            ((System.ComponentModel.ISupportInitialize)(this.Picbox_ModPicture)).EndInit();
            this.Gpb_SortingMethod.ResumeLayout(false);
            this.Gpb_SortingMethod.PerformLayout();
            this.Gpb_Ssquence.ResumeLayout(false);
            this.Gpb_Ssquence.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion
        
        public System.Windows.Forms.TextBox Txtbox_ModFolder;
        public System.Windows.Forms.Button Btn_GetModFolder;
        public System.Windows.Forms.Button Btn_LockModFolder;
        public System.Windows.Forms.ComboBox Selectbox_GameSave;
        public System.Windows.Forms.Button Btn_LockGameSave;
        public System.Windows.Forms.Button Btn_ReadNow;
        public System.Windows.Forms.ListView Lst_ModList;
        public System.Windows.Forms.PictureBox Picbox_ModPicture;
        public System.Windows.Forms.TextBox Txtbox_ModInfoDisplay;
        private System.Windows.Forms.ColumnHeader ModFileNameHeader;
        private System.Windows.Forms.ColumnHeader ModRealNameHeader;
        private System.Windows.Forms.LinkLabel GithubLink;
        public System.Windows.Forms.Button Btn_OpenExplorer;
        public System.Windows.Forms.Button Btn_OpenFile;
        private System.Windows.Forms.GroupBox Gpb_SortingMethod;
        private System.Windows.Forms.RadioButton Rad_ByFileSize;
        private System.Windows.Forms.RadioButton Rad_ByLastModif;
        private System.Windows.Forms.RadioButton Rad_ByFileName;
        private System.Windows.Forms.RadioButton Rad_ByModName;
        private System.Windows.Forms.GroupBox Gpb_Ssquence;
        private System.Windows.Forms.RadioButton Rad_Descending;
        private System.Windows.Forms.RadioButton Rad_Ascending;
    }
}

