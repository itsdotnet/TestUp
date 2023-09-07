using Microsoft.AspNetCore.Http;

namespace TestUp.Service.DTOs.Attachment;

public class AttachmentCreationDto
{
    public IFormFile file { get; set; }
}
