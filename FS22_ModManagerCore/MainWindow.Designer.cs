
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
            ((System.ComponentModel.ISupportInitialize)(this.Picbox_ModPicture)).BeginInit();
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
            this.Lst_ModList.Location = new System.Drawing.Point(760, 93);
            this.Lst_ModList.Name = "Lst_ModList";
            this.Lst_ModList.Size = new System.Drawing.Size(466, 576);
            this.Lst_ModList.TabIndex = 6;
            this.Lst_ModList.UseCompatibleStateImageBehavior = false;
            this.Lst_ModList.View = System.Windows.Forms.View.Details;
            this.Lst_ModList.Click += new System.EventHandler(this.Lst_ModList_Click);
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
            this.Txtbox_ModInfoDisplay.Location = new System.Drawing.Point(394, 177);
            this.Txtbox_ModInfoDisplay.Multiline = true;
            this.Txtbox_ModInfoDisplay.Name = "Txtbox_ModInfoDisplay";
            this.Txtbox_ModInfoDisplay.ReadOnly = true;
            this.Txtbox_ModInfoDisplay.Size = new System.Drawing.Size(311, 393);
            this.Txtbox_ModInfoDisplay.TabIndex = 8;
            // 
            // GithubLink
            // 
            this.GithubLink.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.GithubLink.AutoSize = true;
            this.GithubLink.Font = new System.Drawing.Font("Microsoft YaHei UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GithubLink.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.GithubLink.Location = new System.Drawing.Point(832, 10);
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
            this.Btn_OpenExplorer.Location = new System.Drawing.Point(394, 609);
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
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
    }
}

