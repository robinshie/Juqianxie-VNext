using FileService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain
{
    public interface IFSRepository
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="fileSize"></param>
     /// <param name="sha256Hash"></param>
     /// <returns></returns>
        Task<UploadedItem?> FindFileAsync(long fileSize, string sha256Hash);
    }
}
