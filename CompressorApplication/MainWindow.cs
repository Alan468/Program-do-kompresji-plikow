using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Compresser;

namespace CompressorApplication
{
    public partial class MainWnd : Form
    {
        public List<FileData> fileData = new List<FileData>();
        private Compressor compressor;
        private string pathTo7zip = "C:\\Program Files\\7-Zip\\7z.exe";

        #region CompressionTypes
        // Pliki mieszane -> zip Deflate64 Fastest
        private List<string> SevenZip_LZMA_Ultra = new List<string>() { ".txt", ".bin", ".wav", ".mpg" }; // 7z LZMA normal
        private List<string> Zip_Deflate64_Ultra = new List<string>() { ".mp3", ".mp4" }; // zip Deflate64 Ultra
        private List<string> Zip_PPMd_Ultra = new List<string>() { ".jpg" }; // 7z PPMd ULTRA
        private List<string> SevenZip_BZip2_Ultra = new List<string>() { ".bmp" }; // 7z BZip2 Ultra
        #endregion

        public MainWnd()
        {
            InitializeComponent();
            PathTo7Z.Text = pathTo7zip;
        }

        #region ButtonsActions
        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Program z zadania 'Archiwizacja i kompresja plików' z przedmiotu Archiwizacja i kompresja danych.\nWykonanie:\nAlan Biegun\nJan Snopek\nSekcja 9\n 10-04-2018\n\n" +
                new Compresser.Compressor().Help());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = true,
            };
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadFiles(dialog.FileNames);
            }
            UpdateTable();
        }

        private void AddFolders_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileNames = Directory.GetFiles(dialog.SelectedPath);

                LoadFiles(fileNames);
            }
            UpdateTable();
        }

        private void RemoveSelected_Click(object sender, EventArgs e)
        {
            if (DataTable.SelectedCells.Count > 0)
            {
                var rowId = DataTable.SelectedCells[0].RowIndex;

                fileData.RemoveAt(rowId);

                UpdateTable();
            }
        }
        #endregion

        private void Compress_Click(object sender, EventArgs e)
        {
            compressor = new Compressor(pathTo7zip);

            if (fileData.Count == 0)
            {
                MessageBox.Show("Proszę wybrać co najmniej 1 plik!");
                return;
            }

            var compressionList = new List<CompressionData>();
            var name = "Nazwa_" + DateTime.Now.ToString("dd-MM-yyyy");
            var savePath = "E:\\";

            var saveData = new SaveDialog();
            saveData.ShowDialog();

            if (saveData.SaveFile)
            {
                name = saveData.FileName;
                savePath = saveData.FilePath + "\\";

                if (fileData.All(a => SevenZip_LZMA_Ultra.Contains(a.Format)))
                {
                    compressionList.Add(new CompressionData(name, Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, "", savePath, fileData.Select(a => a.Path + "\\" + a.Name).ToArray()));
                    compressor.Execute(compressionList, savePath, name + " Kompresja Tekstu");
                }
                else if (fileData.All(a => Zip_Deflate64_Ultra.Contains(a.Format)))
                {
                    compressionList.Add(new CompressionData(name, Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, "", savePath, fileData.Select(a => a.Path + "\\" + a.Name).ToArray()));
                    compressor.Execute(compressionList, savePath, name + " Kompresja Muzyki");
                }
                else if (fileData.All(a => Zip_PPMd_Ultra.Contains(a.Format)))
                {
                    compressionList.Add(new CompressionData(name, Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, "", savePath, fileData.Select(a => a.Path + "\\" + a.Name).ToArray()));
                    compressor.Execute(compressionList, savePath, name + " Kompresja JPG");
                }
                else if (fileData.All(a => SevenZip_BZip2_Ultra.Contains(a.Format)))
                {
                    compressionList.Add(new CompressionData(name, Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, "", savePath, fileData.Select(a => a.Path + "\\" + a.Name).ToArray()));
                    compressor.Execute(compressionList, savePath, name + " Kompresja BMP");
                }
                else
                {
                    compressionList.Add(new CompressionData(name, Compression.Normal, ArchiveFormat.SevenZ, Method.Lzma, "", savePath, fileData.Select(a => a.Path + "\\" + a.Name).ToArray()));
                    compressor.Execute(compressionList, savePath, name + " Kompresja MIX");
                }

                MessageBox.Show($"Oryginalny rozmiar: {compressionList[0].OriginalSize.ToString("F")} kB\n" +
                                $"Rozmiar po kompresji: {compressionList[0].CompressedSize.ToString("F")} kB\n" +
                                $"Czas kompresji: {compressionList[0].Time / 1000} sekund\n" +
                                $"Zmniejszono o: {(compressionList[0].OriginalSize - compressionList[0].CompressedSize).ToString("F")} kB\n" +
                                $"Poziom kompresji: {((100 * (compressionList[0].OriginalSize - compressionList[0].CompressedSize)) / compressionList[0].OriginalSize).ToString("F")}%\n" +
                                $"Zapisano w: {compressionList[0].OutputDirectory}\n" +
                                $"Liczba spakowanych plków: {fileData.Count}\n",
                    "Wynik kompresji");
            }
            saveData.Dispose();
        }

        #region Helpers
        private void LoadFiles(string[] filesNames)
        {
            foreach (var item in filesNames)
            {
                var file = new FileInfo(item);

                fileData.Add(new FileData()
                {
                    Creation = file.CreationTime.ToString("dd-MM-yyyy"),
                    Format = file.Extension.ToLower(),
                    Name = file.Name,
                    Modify = file.LastWriteTime.ToString("dd-MM-yyyy"),
                    Path = file.Directory?.FullName ?? "Brak ścieżki (DeepWeb?)",
                    Size = file.Length / 1024D,
                });
            }
        }

        private void ClearTable(DataGridView table)
        {
            var count = table.Rows.Count;
            for (var i = 0; i < count; i++)
            {
                table.Rows.RemoveAt(0);
            }
        }

        private void UpdateTable()
        {
            ClearTable(DataTable);
            var i = 1;
            foreach (var item in fileData)
            {
                DataTable.RowCount++;
                DataTable.Rows[DataTable.RowCount - 1].Cells[0].Value = i++;
                DataTable.Rows[DataTable.RowCount - 1].Cells[1].Value = item.Name;
                DataTable.Rows[DataTable.RowCount - 1].Cells[2].Value = item.Format;
                DataTable.Rows[DataTable.RowCount - 1].Cells[3].Value = item.Size.ToString("F") + "kB";
                DataTable.Rows[DataTable.RowCount - 1].Cells[4].Value = item.Creation;
                DataTable.Rows[DataTable.RowCount - 1].Cells[5].Value = item.Modify;
                DataTable.Rows[DataTable.RowCount - 1].Cells[6].Value = item.Path;
            }
        }
        #endregion

        private void Find7zExe_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                FileName = "7z.exe",
                Filter = "Exe Files (7z.exe)|7z.exe|All Files (7z.exe)|7z.exe",
                FilterIndex = 1,
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                if (dialog.FileName.ToLower().Contains("7z.exe"))
                {
                    PathTo7Z.Text = dialog.FileName;
                    pathTo7zip = PathTo7Z.Text;
                }
                else
                {
                    MessageBox.Show("Wybrano nieprawidłowy plik. Proszę wybrać 7z.exe!", "Błąd", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
