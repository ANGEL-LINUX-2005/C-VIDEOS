using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIDEOS_DE_ALTA_CALIDAD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string titulo = "ANGEL-LINUX";
            Console.WriteLine(titulo.PadLeft((120 + titulo.Length) / 2).PadRight(120));

            string logo = @"
                   ____ 
                .-'    `-.
               /_...._   \
               || ||||   |
               || ||||   |
              (|| ||||   |
              || ||||   |
              || ||||   |
             / ||||||   |
           .'  ||||||   |
        _.'    | ||||   |
     .-'       | ||||   |
    /          | ||||   |
   |    .-.    | ||||   |
   \   (   )   | ||||   |
    '-.__.'    |______.-'
               |_| |_| 
             ANGEL-LINUX";

            foreach (string line in logo.Split('\n'))
            {
                Console.WriteLine(line.PadLeft((120 + line.Length) / 2).PadRight(120));
            }
       
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Console.Write("Ingrese el URL del video del Video:");
            string url = Console.ReadLine();

            Console.Write("Ingrese La Ruta Donde Se Guardara el Video:");
            string outputPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                outputPath = ".";
            }

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "yt-dlp",
                        Arguments = $"-f best[ext=mp4] -o \"{outputPath}/%(title)s.%(ext)s\" {url}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                process.WaitForExit();

                Console.WriteLine("Video descargado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
    