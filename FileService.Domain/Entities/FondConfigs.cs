using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain.Entities
{
    public record FondConfigs : BaseEntity, IHasCreationTime
    {
        public DateTime CreationTime { get; private set; }
        public string Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? Value1 { get; set; }
        public string? Value2 { get; set; }
        public string? Value3 { get; set; }
        public static FondConfigs Create(string Key1, string Key2 = "", string Key3 = "", string Value1 = "", string Value2 = "", string Value3 = "")
        {
            FondConfigs item = new FondConfigs()
            {
                CreationTime = DateTime.Now,
                Key1 = Key1,
                Key2 = Key2,
                Key3 = Key3,
                Value1 = Value1,
                Value2 = Value2,
                Value3 = Value3
            };
            return item;
        }
    }
}
