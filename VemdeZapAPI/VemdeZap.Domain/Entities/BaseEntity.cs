﻿namespace VemdeZap.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
