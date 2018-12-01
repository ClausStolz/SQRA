
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;
using ImageMagick;
using System.Collections.Generic;

namespace SQRA_generator
{
    public class EngineSQRA
    {
        private List<string> data;
        private int elementLength;
        private int animationDelay;

        public EngineSQRA(int aElementLength, int aAnimationDelay, string aData) 
        {
            data = new List<string>();

            elementLength  = aElementLength;
            animationDelay = aAnimationDelay;

            while (aData.Length > elementLength)
            {
                var element = aData.Substring(0, elementLength);
                aData = aData.Remove(0, elementLength);
                data.Add(element);
            }

            if(aData.Length != 0)
            {
                data.Add(aData);
            }
        }

        private void GeneratePngFileFromData(int aPartIndex, int aCount, string aPartData)
        {
            string sumData = aPartIndex.ToString() 
                           + "|" 
                           + aCount.ToString() 
                           + "|" 
                           + aPartData;


            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData           qrCodeData = qrCodeGenerator.CreateQrCode(sumData, QRCodeGenerator.ECCLevel.M);
            PngByteQRCode            qrCode = new PngByteQRCode(qrCodeData);

            byte[] qrCodeAsPngByteArray = qrCode.GetGraphic(20);

            using (Image image = Image.FromStream(new MemoryStream(qrCodeAsPngByteArray)))
            {
                image.Save("test" + aPartIndex.ToString() + ".png", ImageFormat.Png);
            }
        }

        private void GenerateGif(int aCount, int aAnimationDelay, string aGifName)
        {
            using (MagickImageCollection collection = new MagickImageCollection())
            {
                for (int i = 0; i < aCount; i++)
                {
                    collection.Add("test" + i.ToString() + ".png");
                    collection[i].AnimationDelay = aAnimationDelay;
                }

                QuantizeSettings settings = new QuantizeSettings
                {
                    Colors = 256
                };

                collection.Quantize(settings);
                collection.Optimize();

                collection.Write(aGifName + ".gif");
            }
        }

        public void GenerateQRA()
        {
            for (int i = 0; i < data.Count; i++)
            {
                GeneratePngFileFromData(i, data.Count, data[i]);
            }
            GenerateGif(data.Count, animationDelay, "test");
        }
    }
}
