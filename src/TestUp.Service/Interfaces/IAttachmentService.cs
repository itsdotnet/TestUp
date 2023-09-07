using TestUp.Service.DTOs.Attachment;

namespace TestUp.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> DeleteAsync(Attachment attachment);
}