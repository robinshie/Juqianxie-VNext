﻿using System;

namespace Juqianxie.EventBus
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class EventNameAttribute : Attribute
    {
        public EventNameAttribute(string name)
        {
            this.Name = name;
        }
        public string Name { get; init; }
    }
}
