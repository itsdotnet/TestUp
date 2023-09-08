using Microsoft.AspNetCore.Http;

namespace TestUp.Service.DTOs.Attachment;

public class AttachmentCreationDto
{
    public IFormFile File { get; set; }
}
