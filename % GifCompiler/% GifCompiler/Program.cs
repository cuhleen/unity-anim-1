using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using AnimatedGif;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the name of your animation:");
        string gifName = Console.ReadLine();

        Console.WriteLine("Enter the frame rate (fps):");
        int fps = int.Parse(Console.ReadLine());

        int frameRate = 1000 / fps;

        Console.WriteLine("Enter the path to the folder containing the images:");
        string folderPath = Console.ReadLine();

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png");

        //"*"is a wildcard character that matches any sequence of characters in a file or folder name

        using (var gif = AnimatedGif.AnimatedGif.Create(gifName + ".gif", frameRate))
        {
            foreach (string imagePath in imagePaths)
            {
                using (var img = System.Drawing.Image.FromFile(imagePath))
                {
                    gif.AddFrame(img, delay: -1, quality: GifQuality.Bit8);
                }
            }
        }

        Console.WriteLine("GIF creation completed.");
        string gifFilePath = Path.Combine(Directory.GetCurrentDirectory(), "" + gifName + ".gif");
        Process.Start(new ProcessStartInfo { FileName = gifFilePath, UseShellExecute = true });
    }
}
