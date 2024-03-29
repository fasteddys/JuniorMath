﻿using JuniorMath.ApplicationCore.Entities.DoctorAggregate;

using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Entities.SettingsAggregate
{
    public partial class Specality : BaseEntity
    {
        public Specality()
        {
            DoctorSpecality = new HashSet<DoctorSpecality>();
        }

        public string Name { get; set; }

        public virtual ICollection<DoctorSpecality> DoctorSpecality { get; set; }
    }
}
