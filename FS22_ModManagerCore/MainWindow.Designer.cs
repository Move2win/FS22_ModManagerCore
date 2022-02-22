
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Btn_GetModFolder = new System.Windows.Forms.Button();
            this.Btn_LockModFolder = new System.Windows.Forms.Button();
            this.Txtbox_ModFolder = new System.Windows.Forms.TextBox();
            this.Btn_LockGameSave = new System.Windows.Forms.Button();
            this.Btn_ReadNow = new System.Windows.Forms.Button();
            this.Selectbox_GameSave = new System.Windows.Forms.ComboBox();
            this.Lst_ModList = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txtbox_ModInfoDisplay = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.Lst_ModList.HideSelection = false;
            this.Lst_ModList.Location = new System.Drawing.Point(786, 38);
            this.Lst_ModList.Name = "Lst_ModList";
            this.Lst_ModList.Size = new System.Drawing.Size(428, 606);
            this.Lst_ModList.TabIndex = 6;
            this.Lst_ModList.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(51, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 270);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Txtbox_ModInfoDisplay
            // 
            this.Txtbox_ModInfoDisplay.Location = new System.Drawing.Point(391, 183);
            this.Txtbox_ModInfoDisplay.Multiline = true;
            this.Txtbox_ModInfoDisplay.Name = "Txtbox_ModInfoDisplay";
            this.Txtbox_ModInfoDisplay.Size = new System.Drawing.Size(311, 418);
            this.Txtbox_ModInfoDisplay.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Txtbox_ModInfoDisplay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Lst_ModList);
            this.Controls.Add(this.Selectbox_GameSave);
            this.Controls.Add(this.Btn_LockGameSave);
            this.Controls.Add(this.Btn_ReadNow);
            this.Controls.Add(this.Txtbox_ModFolder);
            this.Controls.Add(this.Btn_LockModFolder);
            this.Controls.Add(this.Btn_GetModFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FS22 Mod Manager Core";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox Txtbox_ModInfoDisplay;
    }
}

