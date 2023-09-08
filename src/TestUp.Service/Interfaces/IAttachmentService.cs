using TestUp.Service.DTOs.Attachment;

namespace TestUp.Service.Interfaces;

public interface IAttachmentService
{
    Task<bool> DeleteAsync(long id);
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
}