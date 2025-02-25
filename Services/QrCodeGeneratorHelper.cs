using QRCoder;
using SkiaSharp;
using System;

namespace ChangePond_Visitors_Backend_Application.Services
{
    public static class QrCodeGeneratorHelper
    {
        public static string GenerateQRCode(string text)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
            {
                PngByteQRCode qrCode = new PngByteQRCode(qrCodeData); // ✅ Generates PNG bytes using SkiaSharp
                byte[] qrCodeImage = qrCode.GetGraphic(20);

                return Convert.ToBase64String(qrCodeImage); // ✅ Convert to Base64
            }
        }
    }
}
