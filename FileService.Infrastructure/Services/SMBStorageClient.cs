using FileService.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Infrastructure.Services
{
    public class SMBStorageClient : IStorageClient
    {
        private IOptionsSnapshot<SMBStorageOptions> options;
        public SMBStorageClient(IOptionsSnapshot<SMBStorageOptions> options)
        {
            this.options = options;
        }
        public StorageType StorageType => StorageType.Backup;

        public async Task<Uri> SaveAsync(string key, Stream content, CancellationToken cancellationToken = default)
        {
            if (key.EndsWith('/'))
            {
                throw new ArgumentException("key should not start with /", nameof(key));
            }
            string workingDir = options.Value.WorkingDir?? "D:\\temp\\temp";
            string fullpath = Path.Combine(workingDir, key);
            string dir = Path.GetDirectoryName(fullpath);
            if (!File.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(fullpath)) { File.Delete(fullpath); }
            using (Stream outStream = File.OpenWrite(fullpath))
            {
                await content.CopyToAsync(outStream, cancellationToken);

            }
            return new Uri(fullpath);
        }
    }
}
