using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using ShoppingApp.Application.Abstractions.Services;

namespace ShoppingApp.Infrastructure.Services
{
    public class QrCodeService : IQrCodeService
    {
        public byte[] GenerateQrCode(string text)
        {
            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData data = qrCodeGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new(data);

            byte[] byteGraphic = qrCode.GetGraphic(10, new byte[] { 00, 00, 00 }, new byte[] { 240, 240, 240 });
            return byteGraphic;
        }
    }
}
