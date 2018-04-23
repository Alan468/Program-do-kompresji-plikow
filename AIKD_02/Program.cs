using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Compresser;

namespace AIKD_02
{
    internal class Program
    {
        static void Main()
        {
            var compressor = new Compressor();
            var dirToCompress = "E:\\Pliki\\"; // Ścieżka plików do kompresji
            var dirToSave = "E:\\Wyniki\\";// Ścieżka plików skompresowanych

            List<CompressionData> compressionList;// Lista akcji kompresji do wykonania

            /* 3.1.a Pliki mieszane*/
            #region PlikiMieszane3a
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki mieszane Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave),

                new CompressionData("Pliki mieszane Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra zip PPMd", Compression.Ultra,ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave)
            };
            // Wykonanie kompresji dla podanych parametrów listy i zapisanie logów
            compressor.Execute(compressionList, dirToSave, "Pliki mieszane 3_1_a");

            // Wyczyszenie listy 
            compressionList.Clear();
            #endregion

            /* 3.1.b Pliki mieszane*/
            #region PlikiMieszane3b
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki mieszane Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),

                new CompressionData("Pliki mieszane Maximum 7z LZMA", Compression.Maximum, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Maximum zip Deflate64", Compression.Maximum, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),

                new CompressionData("Pliki mieszane Normal 7z LZMA", Compression.Normal, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Normal zip Deflate64", Compression.Normal, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),

                new CompressionData("Pliki mieszane Fast 7z LZMA", Compression.Fast, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Fast zip Deflate64", Compression.Fast, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),

                new CompressionData("Pliki mieszane Fastest 7z LZMA", Compression.Fastest, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave),
                new CompressionData("Pliki mieszane Fastest zip Deflate64", Compression.Fastest, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave),
            };
            // Wykonanie kompresji dla podanych parametrów listy i zapisanie logów
            compressor.Execute(compressionList, dirToSave, "Pliki mieszane 3_1_b");

            // Wyczyszenie listy 
            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.bin */
            #region PlikiTekstoweBin
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki tekstowe bin Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave, new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Bin}),
                new CompressionData("Pliki tekstowe bin Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Bin}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki tekstowe txt i bin 3_2");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.txt */
            #region PlikiTekstoweTxt
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki tekstowe txt Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Txt}),
                new CompressionData("Pliki tekstowe txt Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Txt}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki tekstowe txt i bin 3_2");

            compressionList.Clear();
            #endregion


            /* 3.2 Kompresja plików *.small bmp*/
            #region PlikiGraficzneSmallBmp
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki graficzne small bmp Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.SmallBmp}),
                new CompressionData("Pliki graficzne small bmp Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.SmallBmp}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki graficzne small bmp 3_3_a");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.big bmp */
            #region PlikiGraficzneBigBmp
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki graficzne big bmp Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.BigBmp}),
                new CompressionData("Pliki graficzne big bmp Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.BigBmp}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki graficzne big bmp 3_3_a");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.big jpg */
            #region PlikiGraficzneBigJpg
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki graficzne big Jpg Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.BigJpg}),
                new CompressionData("Pliki graficzne big Jpg Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.BigJpg}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki graficzne big jpg 3_3_a");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.small jpg */
            #region PlikiGraficzneSmallJpg
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki graficzne Small Jpg Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.SmallJpg}),
                new CompressionData("Pliki graficzne Small Jpg Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.SmallJpg}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki graficzne small jpg 3_3_a");

            compressionList.Clear();
            #endregion


            /* 3.2 Kompresja plików *.mp3 */
            #region PlikiAudioIWideoMp3
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki audio mp3 Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mp3}),
                new CompressionData("Pliki audio mp3 Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mp3}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki audio mp3 3_4");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików*.wav */
            #region PlikiAudioIWideoWav
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki audio Wav Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Wav}),
                new CompressionData("Pliki audio Wav Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Wav}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki audio wav 3_4");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.mp4 */
            #region PlikiAudioIWideoMp4
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki wideo Mp4 Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mp4}),
                new CompressionData("Pliki wideo Mp4 Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mp4}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki wideo mp4 3_4");

            compressionList.Clear();
            #endregion

            /* 3.2 Kompresja plików *.mpg */
            #region PlikiAudioIWideoMpg
            compressionList = new List<CompressionData>
            {
                new CompressionData("Pliki wideo Mpg Ultra 7z LZMA", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra 7z LZMA2", Compression.Ultra, ArchiveFormat.SevenZ, Method.Lzma2, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra 7z PPMd", Compression.Ultra, ArchiveFormat.SevenZ, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra 7z BZip2", Compression.Ultra, ArchiveFormat.SevenZ, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra zip Deflate", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra zip Deflate64", Compression.Ultra, ArchiveFormat.Zip, Method.Deflate64, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra zip BZip2", Compression.Ultra, ArchiveFormat.Zip, Method.BZip2, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra zip LZMA", Compression.Ultra, ArchiveFormat.Zip, Method.Lzma, dirToCompress, dirToSave,new []{Format.Mpg}),
                new CompressionData("Pliki wideo Mpg Ultra zip PPMd", Compression.Ultra, ArchiveFormat.Zip, Method.PpMd, dirToCompress, dirToSave,new []{Format.Mpg}),
            };
            compressor.Execute(compressionList, dirToSave, "Pliki wideo mpg 3_4");

            compressionList.Clear();
            #endregion

            Console.WriteLine("Kompresja zakończona");
            Console.ReadKey();
        }
    }
}