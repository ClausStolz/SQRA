
using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using System.IO;


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
                image.Save("test.png", ImageFormat.Png);
            }
        }
    }
}
