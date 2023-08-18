using FileService.Domain.Entities;
using Juqianxie.Commons;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain
{
    public class FSDomainService
    {
        private readonly IFSRepository repository;
        private readonly IStorageClient backupStorage;//备份服务器
        private readonly IStorageClient remoteStorage;//文件存储服务器

        public FSDomainService(IFSRepository repository,
        IEnumerable<IStorageClient> storageClients)
        {
            this.repository = repository;
            //用这种方式可以解决内置DI不能使用名字注入不同实例的问题，而且从原则上来讲更加优美
            this.backupStorage = storageClients.First(c => c.StorageType == StorageType.Backup);
            //this.remoteStorage = storageClients.First(c => c.StorageType == StorageType.Public);
        }

        public async Task<UploadedItem> UploadAsync(Stream stream, string fileName, CancellationToken cancellationToken)
        {
            string hash = HashHelper.ComputeSha256Hash(stream);
            DateTime today = DateTime.Today;
            long fileSize = stream.Length;
            string key = $"{today.Year}/{today.Month}/{today.Day}/{hash}/{fileName}";
         
            var oldUploadItem = await repository.FindFileAsync(fileSize, hash);
            if (oldUploadItem != null)
            {
                return oldUploadItem;
            }
            //backupStorage实现很稳定、速度很快，一般都使用本地存储（文件共享或者NAS）
            Uri backupUrl = await backupStorage.SaveAsync(key, stream, cancellationToken);//保存到本地备份
            stream.Position = 0;
            //Uri remoteUrl = await remoteStorage.SaveAsync(key, stream, cancellationToken);//保存到生产的存储系统
            //stream.Position = 0;
            //领域服务并不会真正的执行数据库插入，只是把实体对象生成，然后由应用服务和基础设施配合来真正的插入数据库！
            //DDD中尽量避免直接在领域服务中执行数据库的修改（包含删除、新增）操作。
            return UploadedItem.Create(fileSize, fileName, hash, backupUrl);
        }

    }
}
