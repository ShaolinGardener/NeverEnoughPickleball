using Microsoft.AspNetCore.Mvc;
using NEP.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Net.Http;
using System.Text;

namespace NEP.Controllers
{
    public class QRCoderController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytes(qrCodeImage));
        }

        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        [HttpGet]
        public IActionResult GetUserQrCode(string id)
        {
            var qrText = "https://neverenoughpickleball.com/?userId=" + id;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] imageBytes = BitmapToBytes(qrCodeImage);
            return File(imageBytes, "image/png");
        }

        [HttpGet]
        public IActionResult GetSiteQrCode()
        {
            var qrText = "https://neverenoughpickleball.com/";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] imageBytes = BitmapToBytes(qrCodeImage);
            return File(imageBytes, "image/png");
        }
    }
}
