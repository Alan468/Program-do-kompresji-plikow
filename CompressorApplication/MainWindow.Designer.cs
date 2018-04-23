using System.Windows.Forms;

namespace CompressorApplication
{
    partial class MainWnd
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
            this.components = new System.ComponentModel.Container();
            this.FilesPanel = new System.Windows.Forms.Panel();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.Find7zExe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PathTo7Z = new System.Windows.Forms.TextBox();
            this.AddFolders = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.Compress = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.AddFiles = new System.Windows.Forms.Button();
            this.mainWndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FilesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWndBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FilesPanel
            // 
            this.FilesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesPanel.Controls.Add(this.DataTable);
            this.FilesPanel.Location = new System.Drawing.Point(12, 78);
            this.FilesPanel.Name = "FilesPanel";
            this.FilesPanel.Size = new System.Drawing.Size(760, 471);
            this.FilesPanel.TabIndex = 0;
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Format,
            this.Size,
            this.CreationDate,
            this.ModifyDate,
            this.Path});
            this.DataTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTable.Location = new System.Drawing.Point(0, 0);
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowHeadersVisible = false;
            this.DataTable.Size = new System.Drawing.Size(760, 471);
            this.DataTable.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Lp.";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // Name
            // 
            this.Name.HeaderText = "Nazwa";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Format
            // 
            this.Format.HeaderText = "Format";
            this.Format.Name = "Format";
            this.Format.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.HeaderText = "Rozmiar";
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // CreationDate
            // 
            this.CreationDate.HeaderText = "Data stworzenia";
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            // 
            // ModifyDate
            // 
            this.ModifyDate.HeaderText = "Data modyfikacji";
            this.ModifyDate.Name = "ModifyDate";
            this.ModifyDate.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.HeaderText = "Ścieżka";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ControlsPanel.Controls.Add(this.Find7zExe);
            this.ControlsPanel.Controls.Add(this.label1);
            this.ControlsPanel.Controls.Add(this.PathTo7Z);
            this.ControlsPanel.Controls.Add(this.AddFolders);
            this.ControlsPanel.Controls.Add(this.About);
            this.ControlsPanel.Controls.Add(this.Compress);
            this.ControlsPanel.Controls.Add(this.Delete);
            this.ControlsPanel.Controls.Add(this.AddFiles);
            this.ControlsPanel.Location = new System.Drawing.Point(12, 12);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(760, 60);
            this.ControlsPanel.TabIndex = 1;
            // 
            // Find7zExe
            // 
            this.Find7zExe.Location = new System.Drawing.Point(546, 3);
            this.Find7zExe.Name = "Find7zExe";
            this.Find7zExe.Size = new System.Drawing.Size(126, 22);
            this.Find7zExe.TabIndex = 8;
            this.Find7zExe.Text = "Dodaj program";
            this.Find7zExe.UseVisualStyleBackColor = true;
            this.Find7zExe.Click += new System.EventHandler(this.Find7zExe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ścieżka do 7z.exe";
            // 
            // PathTo7Z
            // 
            this.PathTo7Z.Location = new System.Drawing.Point(410, 28);
            this.PathTo7Z.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.PathTo7Z.Name = "PathTo7Z";
            this.PathTo7Z.ReadOnly = true;
            this.PathTo7Z.Size = new System.Drawing.Size(260, 20);
            this.PathTo7Z.TabIndex = 6;
            // 
            // AddFolders
            // 
            this.AddFolders.Location = new System.Drawing.Point(109, 3);
            this.AddFolders.Name = "AddFolders";
            this.AddFolders.Size = new System.Drawing.Size(75, 50);
            this.AddFolders.TabIndex = 5;
            this.AddFolders.Text = "Dodaj katalog";
            this.AddFolders.UseVisualStyleBackColor = true;
            this.AddFolders.Click += new System.EventHandler(this.AddFolders_Click);
            // 
            // About
            // 
            this.About.Location = new System.Drawing.Point(678, 3);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(75, 50);
            this.About.TabIndex = 4;
            this.About.Text = "O programie";
            this.About.UseVisualStyleBackColor = true;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // Compress
            // 
            this.Compress.Location = new System.Drawing.Point(299, 3);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(75, 50);
            this.Compress.TabIndex = 3;
            this.Compress.Text = "Kompresuj";
            this.Compress.UseVisualStyleBackColor = true;
            this.Compress.Click += new System.EventHandler(this.Compress_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(190, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 50);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "Usuń";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.RemoveSelected_Click);
            // 
            // AddFiles
            // 
            this.AddFiles.Location = new System.Drawing.Point(3, 3);
            this.AddFiles.Name = "AddFiles";
            this.AddFiles.Size = new System.Drawing.Size(75, 50);
            this.AddFiles.TabIndex = 0;
            this.AddFiles.Text = "Dodaj pliki";
            this.AddFiles.UseVisualStyleBackColor = true;
            this.AddFiles.Click += new System.EventHandler(this.Add_Click);
            // 
            // mainWndBindingSource
            // 
            this.mainWndBindingSource.DataSource = typeof(CompressorApplication.MainWnd);
            // 
            // MainWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.FilesPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Text = "Sekcja 9 - Kompresor";
            this.FilesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainWndBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FilesPanel;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Format;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.Button Compress;
        private System.Windows.Forms.Button About;
        private Button AddFolders;
        private BindingSource mainWndBindingSource;
        private Button Find7zExe;
        private Label label1;
        private TextBox PathTo7Z;
    }
}

