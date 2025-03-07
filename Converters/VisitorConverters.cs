﻿using ChangePond_Visitors_Backend_Application.Entities;
using ChangePond_Visitors_Backend_Application.RequestDtos;
using ChangePond_Visitors_Backend_Application.ResponseDtos;
using ChangePond_Visitors_Backend_Application.Services;

namespace ChangePond_Visitors_Backend_Application.Converters
{
    public static class VisitorConverters
    {
        public static Visitor ToEntity(this VisitorRequestDto dto)
        {
            // Generate QR Code based on visitor's details (you can customize the data format)
            string qrCodeText = $"{dto.Name},{dto.ContactNumber},{dto.Email},{dto.Purpose}";
            string qrCodeBase64 = QrCodeGeneratorHelper.GenerateQRCode(qrCodeText);

            return new Visitor
            {
                Name = dto.Name,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email,
                Purpose = dto.Purpose,
                HostID = dto.HostID,
                IDProof = dto.IDProof,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                QRCode = qrCodeBase64 // ✅ Store QR code as Base64 string
            };
        }

        // Convert Entity to Response DTO
        public static VisitorResponseDto ToDto(this Visitor visitor)
        {
            return new VisitorResponseDto
            {
                VisitorID = visitor.VisitorID,
                Name = visitor.Name,
                ContactNumber = visitor.ContactNumber,
                Email = visitor.Email,
                Purpose = visitor.Purpose,
                HostID = visitor.HostID,
                HostName = visitor.Host?.Name,  // Ensure Host is loaded
                CheckInTime = visitor.CheckInTime,
                CheckOutTime = visitor.CheckOutTime,
                QRCode = visitor.QRCode,
                Status = visitor.Status,
                IDProof = visitor.IDProof,
                CreatedAt = visitor.CreatedAt
            };
        }

    }
}
