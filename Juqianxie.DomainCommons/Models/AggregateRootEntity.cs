using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juqianxie.DomainCommons.Models
{
    public record AggregateRootEntity : BaseEntity, IAggregateRoot, ISoftDelete, IHasCreationTime, IHasDeletionTime, IHasModificationTime
    {
        public bool IsDeleted { get; private set; }
        public DateTime CreationTime { get; private set; } = DateTime.Now;
        public DateTime? DeletionTime { get; private set; }
        public DateTime? LastModificationTime { get; private set; }

        public void SoftDelete()
        {
            this.IsDeleted = true;
            this.DeletionTime = DateTime.Now;
        }
        public void NotifyModified()
        {
            this.LastModificationTime = DateTime.Now;
        }
    }
}
