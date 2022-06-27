﻿using Health.Core.Types.Enums;

namespace Health.Core.Domain.Common
{
    public class ObjectTag : BaseEntity
    {
        public int TagId { get; set; }
        public int ObjectId { get; set; }
        public TagType TagType { get; set; }
        public virtual Tag Tag { get; set; }
        // public virtual BaseEntity Object { get; set; }
    }
}
