using App2c2pTest.Data.Interface;
using System;
using System.Collections.Generic;

namespace App2c2pTest.Data.Entites
{
    public class EntityBase : IEntity
    {
        public EntityBase()
        {
            IsActive = true;
            DateCreated = DateTime.Now;

        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsTransient()
        {
            return EqualityComparer<int>.Default.Equals(Id, default(int));
        }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        
    }
}
