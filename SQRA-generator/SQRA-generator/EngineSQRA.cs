
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;
using ImageMagick;


namespace SQRA_generator
{
    public class EngineSQRA
    {
        public string Data { get; set; }

        public EngineSQRA(string aData)
        {
            this.Data = aData;
        }

        public void GenerateFromData(string aData)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(aData, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);

            using (Image image = Image.FromStream(new MemoryStream(qrCodeAsPngByteArr)))
            {
                image.Save("test1.png", ImageFormat.Png);
            }
        }

        public void GenerateQRA()
        {
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                // Add first image and set the animation delay to 100ms
                collection.Add("test0.png");
                collection[0].AnimationDelay = 100;

                // Add second image, set the animation delay to 100ms and flip the image
                collection.Add("test1.png");
                collection[1].AnimationDelay = 100;
                collection[1].Flip();

                // Optionally reduce colors
                QuantizeSettings settings = new QuantizeSettings();
                settings.Colors = 256;
                collection.Quantize(settings);

                // Optionally optimize the images (images should have the same size).
                collection.Optimize();

                // Save gif
                collection.Write("test.gif");
            }
        }
    }
}
