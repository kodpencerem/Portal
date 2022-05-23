﻿using System.Collections.Generic;

namespace VedasPortal.Entities.Models.ToplantiTakvimi
{
    public class ToplantiMerkezi : Base.BaseEntity
    {
        public string Adi { get; set; }
        
        public ICollection<ToplantiOdasi> ToplantiOdasi { get; set; }
    }
}
