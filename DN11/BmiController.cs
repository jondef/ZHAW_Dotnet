using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections.Generic;

namespace DN11
{
    public class BMIControl : WebControl
    {
        public double BMI { get; set; }

        protected override void RenderContents(HtmlTextWriter output)
        {
            Thread.Sleep(10);
            var imageUrl = GetImageUrl(BMI);
            output.Write(CreateImageTag(imageUrl));
        }

        private string GetImageUrl(double bmi)
        {
            var imageMap = new Dictionary<Func<double, bool>, string>
            {
                [b => b < 18.5] = "bmiUnderweight.jpg",
                [b => b < 25] = "bmiNormal.jpg",
                [b => b < 30] = "bmiOverweight.jpg",
                [b => b >= 30] = "bmiObese.jpg",
            };

            var imageName = imageMap.First(predicate => predicate.Key(bmi)).Value;
            return ConvertImageToBase64(imageName);
        }

        private string ConvertImageToBase64(string imagePath)
        {
            return HttpContext.Current.Server.MapPath($"~/Images/{imagePath}")
                .Pipe(Image.FromFile)
                .Pipe(image => ConvertToBase64(image, image.RawFormat));
        }

        private static string ConvertToBase64(Image image, ImageFormat format)
        {
            using var memoryStream = new MemoryStream();
            image.Save(memoryStream, format);
            return "data:image/jpeg;base64," + Convert.ToBase64String(memoryStream.ToArray());
        }

        private string CreateImageTag(string imageUrl) => $"<img src=\"{imageUrl}\" alt=\"BMI Image\" />";
    }

    public static class FunctionalExtensions
    {
        public static TOutput Pipe<TInput, TOutput>(this TInput input, Func<TInput, TOutput> func)
        {
            return func(input);
        }
    }
}
