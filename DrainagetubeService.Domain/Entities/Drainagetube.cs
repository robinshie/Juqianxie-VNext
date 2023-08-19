using Juqianxie.DomainCommons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrainagetubeService.Domain.Entities
{
    public record Drainagetube : BaseEntity, IHasCreationTime
    {
        public DateTime CreationTime { get; private set; }
        public string TubeType { get; private set; }
        public string TubePosition { get; private set; }
        public string TubeExtention { get; private set; }
        public Guid Key { get; private set; }
        public long Uid { get; private set; }

        public void Create(string TubeType, string TubePosition, string TubeExtention,long Uid)
        {
            this.Uid = Uid;
            this.CreationTime = DateTime.Now;
            this.TubeType = TubeType;
            this.TubePosition = TubePosition;
            this.TubeExtention = TubeExtention;
            Key=Guid.NewGuid(); 

        }
    }
}
