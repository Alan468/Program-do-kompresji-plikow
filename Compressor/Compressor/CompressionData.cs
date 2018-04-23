using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Compresser
{
    public class CompressionData
    {
        public string Name { get; set; }// Nazwa zestawu
        public long Time { get; set; }// Czas wykonywania kompresji
        public double OriginalSize { get; private set; }// Oryginalny rozmiar
        public double CompressedSize { get; private set; } // Rozmiar po kompresji

        public Format[] FormatsToTake { get; set; }// Lista formatów plików do kompresji
        public string[] FilesToTake { get; set; }

        public Compression Compression { get; }// Rodzaj kompresji (prędkość)
        public ArchiveFormat ArchiveFormat { get; }// Format archiwum
        public Method Method { get; }// Metoda kompresji

        public string Directory { get; }// Scieżka oryginalnych plików
        public string OutputDirectory { get; }// Scieżka zapisu skompresowanego pliku

        /// <summary>
        /// Tworzy i pobiera argumenty dla programu 7zip do wykonania kompresji
        /// </summary>
        /// <returns>Argumenty programu 7zip</returns>
        public string GetArguments()
        {
            var args = " a " + EnumHelper.ToAttributeValue(ArchiveFormat);
            args += " " + EnumHelper.ToAttributeValue(Method);
            args += " -mx=" + (int)Compression;

            args += " " + OutputDirectory + Name.Replace(' ', '_') + "." + EnumHelper.ToDisplayName(ArchiveFormat);

            if (FilesToTake != null &&FilesToTake.Any())
            {
                foreach (var item in FilesToTake)
                {
                    args += " -ir!\"" + item + "\"";
                }
            }
            else
            {
                foreach (var item in FormatsToTake)
                {
                    args += " -ir!" + Directory + "*" + EnumHelper.ToDisplayName(item);
                }
            }

            return args;
        }

        /// <summary>
        /// Towrzenie nowego zestawu kompresji
        /// </summary>
        /// <param name="name">Nazwa zestwu</param>
        /// <param name="compression">Prędkość kompresji</param>
        /// <param name="format">Format archiwum</param>
        /// <param name="method">Metoda kompresji</param>
        /// <param name="directory">Lokalizacja plików do kompresji</param>
        /// <param name="outputDirectory">Lokalizacja zapisu archiwum</param>
        /// <param name="formatsToTake">Format plików do kompresji. Domyślnie Format.All (Wszystkie)</param>
        public CompressionData(string name, Compression compression, ArchiveFormat format, Method method, string directory, string outputDirectory, Format[] formatsToTake = null)
        {
            Directory = directory;
            Name = name;
            Method = method;
            ArchiveFormat = format;
            OutputDirectory = outputDirectory;
            Compression = compression;

            FilesToTake = null;
            FormatsToTake = (formatsToTake == null || formatsToTake.Contains(Format.All) || formatsToTake.Length == 0) ? new[] { Format.All } : formatsToTake;
        }

        /// <summary>
        /// Towrzenie nowego zestawu kompresji
        /// </summary>
        /// <param name="name">Nazwa zestwu</param>
        /// <param name="compression">Prędkość kompresji</param>
        /// <param name="format">Format archiwum</param>
        /// <param name="method">Metoda kompresji</param>
        /// <param name="directory">Lokalizacja plików do kompresji</param>
        /// <param name="outputDirectory">Lokalizacja zapisu archiwum</param>
        /// <param name="filesToTake">Lista plików do kompresji.</param>
        public CompressionData(string name, Compression compression, ArchiveFormat format, Method method, string directory, string outputDirectory, params string[] filesToTake)
        {
            Directory = directory;
            Name = name;
            Method = method;
            ArchiveFormat = format;
            OutputDirectory = outputDirectory;
            Compression = compression;

            FormatsToTake = null;
            FilesToTake = filesToTake;
        }

        // Pobranie oryginalnego rozmiaru plików
        public void GetOriginalSize()
        {
            OriginalSize = 0;
            // Pobranie rozmiaru każdego pliku i sumowanie :/
            if (FilesToTake!= null && FilesToTake.Any())
            {
                foreach (var item in FilesToTake)
                {
                    OriginalSize += new FileInfo(item).Length;
                }
            }
            else
            {
                foreach (var item in FormatsToTake)
                {
                    var filesInDir = System.IO.Directory.GetFiles(Directory, "*" + EnumHelper.ToDisplayName(item));
                    OriginalSize += filesInDir.Select(name => new FileInfo(name)).Select(info => info.Length).Sum();
                }
            }
            OriginalSize /= 1024.0;
        }

        // Pobranie skompresowanego archiwum
        public void GetArchiveSize()
        {
            CompressedSize = new FileInfo(OutputDirectory + "\\" + Name.Replace(' ', '_') + "." + EnumHelper.ToDisplayName(ArchiveFormat)).Length;
            CompressedSize /= 1024.0;
        }
    }

    // Rodzaje kompresji
    public enum Compression
    {
        [Display(Name = "Najszybsza")]
        Fastest = 1,
        [Display(Name = "Szybka")]
        Fast = 3,
        [Display(Name = "Normalna")]
        Normal = 5,
        [Display(Name = "Maksymalna")]
        Maximum = 7,
        [Display(Name = "Ultra")]
        Ultra = 9
    }

    // Rodzaje archiwum i argumentu 
    public enum ArchiveFormat
    {
        [Display(Name = "7z")]
        [Description("-t7z")]
        SevenZ = 1,
        [Display(Name = "zip")]
        [Description("-tzip")]
        Zip = 2,
    }

    // Rodzaje metod kompresji i argumenty
    public enum Method
    {
        [Description("-mm=lzma")]
        Lzma = 1,
        [Description("-mm=lzma2")]
        Lzma2 = 2,
        [Description("-mm=ppmd")]
        PpMd = 3,
        [Description("-mm=bzip2")]
        BZip2 = 4,
        [Description("-mm=deflate")]
        Deflate = 5,
        [Description("-mm=deflate64")]
        Deflate64 = 6
    }

    // Formaty plików do kompresji
    public enum Format
    {
        [Display(Name = ".*")]
        All,

        [Display(Name = ".jpg")]
        Jpg,
        [Display(Name = ".sjpg")]
        SmallJpg,
        [Display(Name = ".bjpg")]
        BigJpg,

        [Display(Name = ".bmp")]
        Bmp,
        [Display(Name = ".bbmp")]
        BigBmp,
        [Display(Name = ".sbmp")]
        SmallBmp,

        [Display(Name = ".txt")]
        Txt,
        [Display(Name = ".bin")]
        Bin,

        [Display(Name = ".mp4")]
        Mp4,
        [Display(Name = ".mpg")]
        Mpg,

        [Display(Name = ".wav")]
        Wav,
        [Display(Name = ".mp3")]
        Mp3,
    }

    // Helper do pobierania adnotacji (nazw i argumentów(jako opis)
    public static class EnumHelper
    {
        // Pobranie atrybutów pola
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var memberInfo = value.GetType().GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes.FirstOrDefault();
        }
        // Pobranie atrybutu Name (nazwa pola)
        public static string ToDisplayName(Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }
        // Pobranie atrybutu Description (argumenty funkcji)
        public static string ToAttributeValue(Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
