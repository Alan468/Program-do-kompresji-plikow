using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompressorApplication
{
    public partial class SaveDialog : Form
    {
        public bool SaveFile { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public SaveDialog()
        {
            InitializeComponent();
            SaveFile = false;
            Name.Text = "Kompresja";
            Path.Text = "C:\\Compression";
        }

        private void Select_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Path.Text = dialog.SelectedPath;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SaveFile = false;
            this.Hide();
            this.Close();
        }

        private void Compress_Click(object sender, EventArgs e)
        {
            if (Name.Text.Length > 2 && Path.Text.Length > 0)
            {
                FileName = Name.Text;
                FilePath = Path.Text;
                SaveFile = true;
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Prosze podać nazwę pliku(minimum 3 znaki) oraz ścieżke!");
            }
        }
    }
}
