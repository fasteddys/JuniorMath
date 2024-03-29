﻿using System.Collections.Generic;

namespace JuniorMath.ApplicationCore.Entities.UserAggregate
{
    public partial class SiteUserLevel : BaseEntity
    {
        public SiteUserLevel()
        {
            SiteUser = new HashSet<SiteUser>();
        }
        public string Name { get; set; }

        public virtual ICollection<SiteUser> SiteUser { get; set; }
    }
}
