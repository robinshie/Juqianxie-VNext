﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juqianxie.DomainCommons.Models
{
    public interface IHasModificationTime
    {
        DateTime? LastModificationTime { get; }

    }
}
