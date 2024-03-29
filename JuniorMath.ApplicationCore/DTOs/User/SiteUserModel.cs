﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.User
{
    public class SiteUserModel
    {
        public int SiteUserId { get; set; }
        public string UserId { get; set; }
        public int SiteUserLevelId { get; set; }
        public string SiteUserLevelName { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsDoctor { get; set; }
    }
}
