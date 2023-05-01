using System;
using System.IO;
using Xamarin.Forms;

namespace CRUD_SQLITE.ViewModels
{
    public static class ConvertImage
    {
        public static ImageSource ToPNG(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                Stream stream = new MemoryStream(imageBytes);
                return ImageSource.FromStream(() => stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static string ImageDefault()
        {
            var img = ImageSource.FromFile("image.png");

            var png = ImageSource.FromResource("image.png");

            var base64Data = "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";

            return base64Data;
        }
    }
}