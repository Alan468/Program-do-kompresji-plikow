using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Compresser
{
    public class Compressor
    {
        private Stopwatch watch = Stopwatch.StartNew();// Odmierzanie czasu kompresji plików
        private ProcessStartInfo startInfo = new ProcessStartInfo();// Uruchomienie 7zip z zadanymi argumentami

        /// <summary>
        /// Tworzenie nowego kompressora
        /// </summary>
        /// <param name="pathTo7zip">Ścieżka do pliku 7z.exe. Domyślnie "C:\\Program Files\\7-Zip\\7z.exe"</param>
        public Compressor(string pathTo7zip = "C:\\Program Files\\7-Zip\\7z.exe")
        {
            startInfo.FileName = pathTo7zip;
        }

        /// <summary>
        /// Wykonanie operacji kompresji na elementach zdefiniowanych w liście commpressionList, każdy element tworzy nowe archiwum
        /// </summary>
        /// <param name="compressionList">Lista zdefiniowanych operacji kompresji</param>
        /// <param name="logDir">Lokalizacja zapisu logu kompresji. Jeśli NULL nie tworzy logu</param>
        /// <param name="logName">Nazwa log kompresji. Jeśli NULL nie tworzy logu</param>
        public void Execute(List<CompressionData> compressionList, string logDir = null, string logName = null)
        {
            // Dla każdego przypadku w liśćie
            foreach (var data in compressionList)
            {
                data.GetOriginalSize();// Pobierz oryginalny rozmiar

                startInfo.Arguments = data.GetArguments();// Utwórz argumenty dla podanego przypadku

                // Zresetuj i uruchom licznik
                watch.Reset();
                watch.Start();

                Process.Start(startInfo)?.WaitForExit();// Wykonaj program

                watch.Stop();// Zatrzymaj licznik

                data.Time = watch.ElapsedMilliseconds;// Zapisz czas wykonywania

                data.GetArchiveSize();// Pobranie rozmiaru archiwum
            }
            // Zapisanie logów jeśli podano dane
            if (!string.IsNullOrWhiteSpace(logDir) && !string.IsNullOrWhiteSpace(logName))
            {
                SaveLogs(compressionList, logDir, logName + "_" + DateTime.Now);
            }
        }

        // Tworzenie logów kompresji
        private void SaveLogs(List<CompressionData> compressionList, string path, string name)
        {
            // Towrzenie tabeli w HTML z wynikami
            var good = "style=\"background-color: #51e65680;\"";
            var bad = "style=\"background-color: #e6515180;\"";
            var ugly = "style =\"display: none;\"";

            name = (name.Replace('.', '_').Replace(':', '_'));
            using (var writer = new StreamWriter(new FileStream(path + "/" + name + ".html", FileMode.Create)))
            {
                writer.Write("<table border=\"1\" cellspacing=\"0\" style=\"text-align: center;\">");
                writer.Write("<tr>");

                writer.Write("<th>Nazwa</th>");
                writer.Write("<th style=\"width: 600px;\">Argumenty</th>");

                writer.Write("<th>Rodzaj kompresji</th>");
                writer.Write("<th>Format</th>");
                writer.Write("<th>Metod kompresji</th>");

                writer.Write("<th>Czas kompresji</th>");
                writer.Write("<th>Oryginalny rozmiar</th>");
                writer.Write("<th>Rozmiar po kompresji</th>");

                writer.Write("<th>Uzyskana kompresja</th>");
                writer.Write("<th>Uzyskana kompresja %</th>");

                writer.Write("</tr>");

                var minTime = compressionList.Min(a => a.Time);
                var maxTime = compressionList.Max(a => a.Time);

                var minComp = compressionList.Min(a => a.CompressedSize);
                var maxComp = compressionList.Max(a => a.CompressedSize);

                foreach (var item in compressionList)
                {
                    writer.Write("<tr>");

                    writer.Write("<td style=\"text-align: left;\">" + item.Name + "</td>");
                    writer.Write("<td style=\"width: 600px;\">7z.exe " + item.GetArguments() + "</td>");

                    writer.Write("<td>" + EnumHelper.ToDisplayName(item.Compression) + "</td>");
                    writer.Write("<td>" + EnumHelper.ToDisplayName(item.ArchiveFormat) + "</td>");
                    writer.Write("<td>" + item.Method + "</td>");

                    writer.Write("<td " + (minTime == item.Time ? good : (maxTime == item.Time ? bad : "")) + ">" + item.Time + "mls</td>");
                    writer.Write("<td>" + item.OriginalSize.ToString("F") + "kB</td>");
                    writer.Write("<td>" + item.CompressedSize.ToString("F") + "kB</td>");

                    var difference = (item.OriginalSize - item.CompressedSize);
                    writer.Write("<td " + (minComp == item.CompressedSize ? good : (maxComp == item.CompressedSize ? bad : "")) + ">" + difference.ToString("F") + "kB</td>");
                    var differencePercent = (100 * difference) / item.OriginalSize;
                    writer.Write("<td " + (minComp == item.CompressedSize ? good : (maxComp == item.CompressedSize ? bad : "")) + ">" + differencePercent.ToString("F") + "%</td>");

                    writer.Write("</tr>");
                }
                writer.Write("<tr><th colspan=\"100%\"><marquee><b><i><u>Alloner was here 25-03-2018 22:30 - Alloner&Johnny ©</u></i></b></marquee></th></tr>");
                writer.Write("</table>");
            }
        }

        public string Help()
        {
            return
                "Alloner&Johnny C 2018 :P :D \n"+
                "Przykład użycia\n" +
                "var compressor = new Compressor();\n" +
                "var compressionList = new List<CompressionData>\n" +
                "{\n" +
                "\tnew CompressionData(\"Nazwa/Opis\", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, \"C:\\FolderToCompress\\\", \"C:\\\"),\n" +
                "... \n" +
                "}\n"
                + "compressor.Execute(compressionList, \"C:\\\", \"Nazwa logu\");\n";
        }
    }
}
