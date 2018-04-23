namespace CompressorApplication
{
    partial class SaveDialog
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
            this.Compress = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Select = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Compress
            // 
            this.Compress.Location = new System.Drawing.Point(197, 126);
            this.Compress.Name = "Compress";
            this.Compress.Size = new System.Drawing.Size(75, 23);
            this.Compress.TabIndex = 0;
            this.Compress.Text = "Kompresuj";
            this.Compress.UseVisualStyleBackColor = true;
            this.Compress.Click += new System.EventHandler(this.Compress_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(116, 126);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Anuluj";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scieżka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nazwa: ";
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(245, 52);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(28, 23);
            this.Select.TabIndex = 4;
            this.Select.Text = "...";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // Path
            // 
            this.Path.Location = new System.Drawing.Point(64, 54);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(175, 20);
            this.Path.TabIndex = 5;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(64, 22);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(175, 20);
            this.Name.TabIndex = 6;
            // 
            // SaveDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.Select);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Compress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Kompresja";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Compress;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.TextBox Path;
        private System.Windows.Forms.TextBox Name;
    }
}