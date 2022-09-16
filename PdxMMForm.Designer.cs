namespace PdxModManager
{
    partial class PdxMMForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridInstalledMods = new System.Windows.Forms.DataGridView();
            this.gridViewColumnModList_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewColumnModList_Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewColumnModList_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInfoPublishedDate = new System.Windows.Forms.Label();
            this.lblLinkInfoSteamWorkshop = new System.Windows.Forms.LinkLabel();
            this.lblInfoSize = new System.Windows.Forms.Label();
            this.lblInfoSupportedGameVersion = new System.Windows.Forms.Label();
            this.lblInfoVersion = new System.Windows.Forms.Label();
            this.lblInfoName = new System.Windows.Forms.Label();
            this.picBoxMod = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.prgsBar = new System.Windows.Forms.ProgressBar();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bSourceModList = new System.Windows.Forms.BindingSource(this.components);
            this.bSourceQueueList = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridModQueue = new System.Windows.Forms.DataGridView();
            this.btnForceUpdate = new System.Windows.Forms.Button();
            this.gridViewColumnQueueList_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewColumnQueueList_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewColumnQueueList_Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewColumnQueueList_ETA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstalledMods)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceModList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceQueueList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModQueue)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridInstalledMods
            // 
            this.dataGridInstalledMods.AllowUserToAddRows = false;
            this.dataGridInstalledMods.AllowUserToDeleteRows = false;
            this.dataGridInstalledMods.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridInstalledMods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridInstalledMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInstalledMods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewColumnModList_Name,
            this.gridViewColumnModList_Version,
            this.gridViewColumnModList_Size});
            this.dataGridInstalledMods.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridInstalledMods.Location = new System.Drawing.Point(0, 0);
            this.dataGridInstalledMods.Name = "dataGridInstalledMods";
            this.dataGridInstalledMods.ReadOnly = true;
            this.dataGridInstalledMods.RowHeadersVisible = false;
            this.dataGridInstalledMods.RowTemplate.Height = 25;
            this.dataGridInstalledMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridInstalledMods.Size = new System.Drawing.Size(771, 345);
            this.dataGridInstalledMods.TabIndex = 0;
            this.dataGridInstalledMods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMods_CellClick);
            // 
            // gridViewColumnModList_Name
            // 
            this.gridViewColumnModList_Name.DataPropertyName = "name";
            this.gridViewColumnModList_Name.HeaderText = "Name";
            this.gridViewColumnModList_Name.Name = "gridViewColumnModList_Name";
            this.gridViewColumnModList_Name.ReadOnly = true;
            this.gridViewColumnModList_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewColumnModList_Name.Width = 420;
            // 
            // gridViewColumnModList_Version
            // 
            this.gridViewColumnModList_Version.DataPropertyName = "version";
            this.gridViewColumnModList_Version.HeaderText = "Version";
            this.gridViewColumnModList_Version.Name = "gridViewColumnModList_Version";
            this.gridViewColumnModList_Version.ReadOnly = true;
            this.gridViewColumnModList_Version.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gridViewColumnModList_Size
            // 
            this.gridViewColumnModList_Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridViewColumnModList_Size.DataPropertyName = "size";
            this.gridViewColumnModList_Size.HeaderText = "Size";
            this.gridViewColumnModList_Size.Name = "gridViewColumnModList_Size";
            this.gridViewColumnModList_Size.ReadOnly = true;
            this.gridViewColumnModList_Size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(9, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(779, 23);
            this.txtPath.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(457, 558);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(64, 15);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status: Idle";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInfoPublishedDate);
            this.groupBox2.Controls.Add(this.lblLinkInfoSteamWorkshop);
            this.groupBox2.Controls.Add(this.lblInfoSize);
            this.groupBox2.Controls.Add(this.lblInfoSupportedGameVersion);
            this.groupBox2.Controls.Add(this.lblInfoVersion);
            this.groupBox2.Controls.Add(this.lblInfoName);
            this.groupBox2.Controls.Add(this.picBoxMod);
            this.groupBox2.Location = new System.Drawing.Point(9, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 136);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mod Info";
            // 
            // lblInfoPublishedDate
            // 
            this.lblInfoPublishedDate.AutoSize = true;
            this.lblInfoPublishedDate.Location = new System.Drawing.Point(124, 82);
            this.lblInfoPublishedDate.Name = "lblInfoPublishedDate";
            this.lblInfoPublishedDate.Size = new System.Drawing.Size(108, 15);
            this.lblInfoPublishedDate.TabIndex = 6;
            this.lblInfoPublishedDate.Text = "ModPublishedDate";
            // 
            // lblLinkInfoSteamWorkshop
            // 
            this.lblLinkInfoSteamWorkshop.AutoSize = true;
            this.lblLinkInfoSteamWorkshop.Location = new System.Drawing.Point(124, 110);
            this.lblLinkInfoSteamWorkshop.Name = "lblLinkInfoSteamWorkshop";
            this.lblLinkInfoSteamWorkshop.Size = new System.Drawing.Size(121, 15);
            this.lblLinkInfoSteamWorkshop.TabIndex = 5;
            this.lblLinkInfoSteamWorkshop.TabStop = true;
            this.lblLinkInfoSteamWorkshop.Text = "Steam Workshop URL";
            this.lblLinkInfoSteamWorkshop.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkInfoSteamWorkshop_LinkClicked);
            // 
            // lblInfoSize
            // 
            this.lblInfoSize.AutoSize = true;
            this.lblInfoSize.Location = new System.Drawing.Point(124, 67);
            this.lblInfoSize.Name = "lblInfoSize";
            this.lblInfoSize.Size = new System.Drawing.Size(52, 15);
            this.lblInfoSize.TabIndex = 4;
            this.lblInfoSize.Text = "ModSize";
            // 
            // lblInfoSupportedGameVersion
            // 
            this.lblInfoSupportedGameVersion.AutoSize = true;
            this.lblInfoSupportedGameVersion.Location = new System.Drawing.Point(124, 52);
            this.lblInfoSupportedGameVersion.Name = "lblInfoSupportedGameVersion";
            this.lblInfoSupportedGameVersion.Size = new System.Drawing.Size(156, 15);
            this.lblInfoSupportedGameVersion.TabIndex = 3;
            this.lblInfoSupportedGameVersion.Text = "ModSupportedGameVersion";
            // 
            // lblInfoVersion
            // 
            this.lblInfoVersion.AutoSize = true;
            this.lblInfoVersion.Location = new System.Drawing.Point(124, 37);
            this.lblInfoVersion.Name = "lblInfoVersion";
            this.lblInfoVersion.Size = new System.Drawing.Size(70, 15);
            this.lblInfoVersion.TabIndex = 2;
            this.lblInfoVersion.Text = "ModVersion";
            // 
            // lblInfoName
            // 
            this.lblInfoName.AutoSize = true;
            this.lblInfoName.Location = new System.Drawing.Point(124, 22);
            this.lblInfoName.Name = "lblInfoName";
            this.lblInfoName.Size = new System.Drawing.Size(64, 15);
            this.lblInfoName.TabIndex = 1;
            this.lblInfoName.Text = "ModName";
            // 
            // picBoxMod
            // 
            this.picBoxMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxMod.Location = new System.Drawing.Point(6, 22);
            this.picBoxMod.Name = "picBoxMod";
            this.picBoxMod.Size = new System.Drawing.Size(112, 103);
            this.picBoxMod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMod.TabIndex = 0;
            this.picBoxMod.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(376, 555);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(295, 555);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update All";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // prgsBar
            // 
            this.prgsBar.Location = new System.Drawing.Point(0, 331);
            this.prgsBar.Name = "prgsBar";
            this.prgsBar.Size = new System.Drawing.Size(771, 14);
            this.prgsBar.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 555);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete mod";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 555);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add mod";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 183);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 373);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridInstalledMods);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(771, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Installed Mods";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridModQueue);
            this.tabPage2.Controls.Add(this.prgsBar);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(771, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Queue";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridModQueue
            // 
            this.dataGridModQueue.AllowUserToAddRows = false;
            this.dataGridModQueue.AllowUserToDeleteRows = false;
            this.dataGridModQueue.AllowUserToResizeColumns = false;
            this.dataGridModQueue.AllowUserToResizeRows = false;
            this.dataGridModQueue.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridModQueue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridModQueue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridModQueue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridViewColumnQueueList_Name,
            this.gridViewColumnQueueList_Status,
            this.gridViewColumnQueueList_Progress,
            this.gridViewColumnQueueList_ETA});
            this.dataGridModQueue.Location = new System.Drawing.Point(0, 0);
            this.dataGridModQueue.Name = "dataGridModQueue";
            this.dataGridModQueue.ReadOnly = true;
            this.dataGridModQueue.RowHeadersVisible = false;
            this.dataGridModQueue.RowHeadersWidth = 4;
            this.dataGridModQueue.RowTemplate.Height = 25;
            this.dataGridModQueue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridModQueue.Size = new System.Drawing.Size(771, 325);
            this.dataGridModQueue.TabIndex = 0;
            // 
            // btnForceUpdate
            // 
            this.btnForceUpdate.Location = new System.Drawing.Point(176, 555);
            this.btnForceUpdate.Name = "btnForceUpdate";
            this.btnForceUpdate.Size = new System.Drawing.Size(113, 23);
            this.btnForceUpdate.TabIndex = 11;
            this.btnForceUpdate.Text = "Force Update All";
            this.btnForceUpdate.UseVisualStyleBackColor = true;
            this.btnForceUpdate.Click += new System.EventHandler(this.btnForceUpdate_Click);
            // 
            // gridViewColumnQueueList_Name
            // 
            this.gridViewColumnQueueList_Name.DataPropertyName = "name";
            this.gridViewColumnQueueList_Name.HeaderText = "Name";
            this.gridViewColumnQueueList_Name.Name = "gridViewColumnQueueList_Name";
            this.gridViewColumnQueueList_Name.ReadOnly = true;
            this.gridViewColumnQueueList_Name.Width = 400;
            // 
            // gridViewColumnQueueList_Status
            // 
            this.gridViewColumnQueueList_Status.DataPropertyName = "status";
            this.gridViewColumnQueueList_Status.HeaderText = "Status";
            this.gridViewColumnQueueList_Status.Name = "gridViewColumnQueueList_Status";
            this.gridViewColumnQueueList_Status.ReadOnly = true;
            this.gridViewColumnQueueList_Status.Width = 75;
            // 
            // gridViewColumnQueueList_Progress
            // 
            this.gridViewColumnQueueList_Progress.DataPropertyName = "progress";
            this.gridViewColumnQueueList_Progress.HeaderText = "Progress";
            this.gridViewColumnQueueList_Progress.Name = "gridViewColumnQueueList_Progress";
            this.gridViewColumnQueueList_Progress.ReadOnly = true;
            // 
            // gridViewColumnQueueList_ETA
            // 
            this.gridViewColumnQueueList_ETA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridViewColumnQueueList_ETA.DataPropertyName = "eta";
            this.gridViewColumnQueueList_ETA.HeaderText = "ETA";
            this.gridViewColumnQueueList_ETA.Name = "gridViewColumnQueueList_ETA";
            this.gridViewColumnQueueList_ETA.ReadOnly = true;
            // 
            // PdxMMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 582);
            this.Controls.Add(this.btnForceUpdate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PdxMMForm";
            this.Text = "PdxMM";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInstalledMods)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceModList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceQueueList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModQueue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtPath;
        private DataGridView dataGridInstalledMods;
        private Label lblStatus;
        private GroupBox groupBox2;
        private PictureBox picBoxMod;
        private Label lblInfoSize;
        private Label lblInfoSupportedGameVersion;
        private Label lblInfoVersion;
        private Label lblInfoName;
        private LinkLabel lblLinkInfoSteamWorkshop;
        private Button btnRefresh;
        private Label lblInfoPublishedDate;
        private Button btnUpdate;
        private ProgressBar prgsBar;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dataGridModQueue;
        private BindingSource bSourceModList;
        private BindingSource bSourceQueueList;
        private DataGridViewTextBoxColumn gridViewColumnModList_Name;
        private DataGridViewTextBoxColumn gridViewColumnModList_Version;
        private DataGridViewTextBoxColumn gridViewColumnModList_Size;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnForceUpdate;
        private DataGridViewTextBoxColumn gridViewColumnQueueList_Name;
        private DataGridViewTextBoxColumn gridViewColumnQueueList_Status;
        private DataGridViewTextBoxColumn gridViewColumnQueueList_Progress;
        private DataGridViewTextBoxColumn gridViewColumnQueueList_ETA;
    }
}