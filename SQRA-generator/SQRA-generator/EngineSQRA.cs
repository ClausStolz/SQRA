using System;
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
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            SvgQRCode qrCode = new SvgQRCode(qrCodeData);
            string qrCodeAsSvg = qrCode.GetGraphic(20);

            File.WriteAllText("test.svg", qrCodeAsSvg);
        }
    }
}
