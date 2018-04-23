using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompressorApplication
{
    public class FileData
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public double Size { get; set; }
        public string Creation { get; set; }
        public string Modify { get; set; }
        public string Path { get; set; }

        public void ShowData()
        {
            MessageBox.Show(
                $"Nazwa: {Name} " +
                $"\nFormat: {Format} " +
                $"\nRozmiar: {Size}kB " +
                $"\nData stworzenia: {Creation} " +
                $"\nData modyfikacji: {Modify} " +
                $"\nŚcieżka: {Path}",
                "Informacje",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
