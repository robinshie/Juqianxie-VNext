using FluentValidation;

namespace FileService.WebAPI.Uploader
{
    public class UploadRequest
    {
        public IFormFile File { get; set; }
    }
    public class UploadRequestValidator : AbstractValidator<UploadRequest>
    {
        public UploadRequestValidator()
        {
            long maxFileSize = 50 * 1024 * 1024;
            RuleFor(e => e.File).NotNull().Must(f => f.Length > 0 && f.Length < maxFileSize);
        }

    }
}
