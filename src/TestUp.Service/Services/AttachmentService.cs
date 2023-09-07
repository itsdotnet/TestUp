using TestUp.DataAccess.IRepositories;
using TestUp.Service.DTOs.Attachment;
using TestUp.Service.Exceptions;
using TestUp.Service.Extensions;
using TestUp.Service.Helpers;
using TestUp.Service.Interfaces;

namespace TestUp.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> _attachmentRepository;

    public AttachmentService(IRepository<Attachment> repository)
    {
        _attachmentRepository = repository;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var attachment = await _attachmentRepository.SelectAsync(x => x.Id == id);

        if (attachment is null)
            throw new NotFoundException("Attachment not found");

        await _attachmentRepository.DeleteAsync(x => x == attachment);
        await _attachmentRepository.SaveAsync();

        return true;
    }

    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Images");

        if (!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileName = MediaHelper.MakeImageName(dto.File.FileName);
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.File.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullPath
        };

        await _attachmentRepository.AddAsync(createdAttachment);
        await _attachmentRepository.SaveAsync();

        return createdAttachment;
    }
}
