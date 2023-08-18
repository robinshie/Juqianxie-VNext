using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonInitializer
{
    public interface IProtectService
    {
        public string Encrypt(string textToEncrypt, string key);
        public string Decrypt(string cipherText, string key);
    }
    public class ProtectService : IProtectService
    {
        protected readonly ILogger<ProtectAtribuild> Logger;
        private readonly IDataProtectionProvider dataProtector;
        public ProtectService(ILogger<ProtectAtribuild> logger, IDataProtectionProvider dataProtector)
        {
            Logger = logger;
            this.dataProtector = dataProtector;
        }
        public string Encrypt(string textToEncrypt, string key)
        {
            return dataProtector.CreateProtector(key).Protect(textToEncrypt);
        }

        public string Decrypt(string cipherText, string key)
        {
            return dataProtector.CreateProtector(key).Unprotect(cipherText);
        }

    }
}
