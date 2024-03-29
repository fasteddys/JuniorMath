﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.Items
{
     public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int? ServiceGroupId { get; set; }
        public string ShortCode { get; set; }
        public int? IndustryCodeId { get; set; }
        public bool Subscription { get; set; }
    }
}
