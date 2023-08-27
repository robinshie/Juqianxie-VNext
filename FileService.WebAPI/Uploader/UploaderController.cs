﻿using CommonInitializer;
using FileService.Domain;
using FileService.Domain.Entities;
using FileService.Infrastructure;
using FileService.Respository;
using Juqianxie.ASPNETCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileService.WebAPI.Uploader
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [UnitOfWork(typeof(FSDbContext))]
    public class UploaderController : ControllerBase
    {
        private readonly FSDbContext dbContext;
        private readonly FSDomainService domainService;
        private readonly Domain.IFSRepository repository;
        private readonly IFondConfigsRepository fondConfigsRepository;
        public UploaderController(FSDomainService domainService, FSDbContext dbContext, Domain.IFSRepository repository, IFondConfigsRepository fondConfigsRepository)
        {
            this.domainService = domainService;
            this.dbContext = dbContext;
            this.repository = repository;
            this.fondConfigsRepository = fondConfigsRepository;
        }

        /// <summary>
        /// 检查是否有和指定的大小和SHA256完全一样的文件
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<FileExistsResponse> FileExists(long fileSize, string sha256Hash)
        {
            var item = await repository.FindFileAsync(fileSize, sha256Hash);
            if (item == null)
            {
                return new FileExistsResponse(false, null);
            }
            else
            {
                return new FileExistsResponse(true, item.RemoteUrl);
            }
        }
        [HttpPost]
        public async Task<IEnumerable<FondConfigs>> GetConfigs(IEnumerable<JConfig> jConfigs )
        {
            if (jConfigs == null)
            {
                return null;
            }
            return await fondConfigsRepository.FindAllConfigs(jConfigs);
        }

        //todo: 做好校验，参考OSS的接口，防止被滥用
        //todo：应该由应用服务器向fileserver申请一个上传码（可以指定申请的个数，这个接口只能供应用服务器调用），
        //页面直传只能使用上传码上传一个文件，防止接口被恶意利用。应用服务器要控制发放上传码的频率。
        //todo：再提供一个非页面直传的接口，供服务器用
        [HttpPost]
        [RequestSizeLimit(60_000_000)]
        public async Task<ActionResult<Uri>> Upload([FromForm] UploadRequest request, CancellationToken cancellationToken = default)
        {
            var file = request.File;
            string fileName = file.FileName;
            using Stream stream = file.OpenReadStream();
            var upItem = await domainService.UploadAsync(stream, fileName, cancellationToken);
            dbContext.Add(upItem);
            return upItem.RemoteUrl;
        }

    }
}
