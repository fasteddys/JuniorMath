﻿using JuniorMath.ApplicationCore.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Adresses
{
    public class AddressViewModel
    {

        [Display(Name = "Address Type")]
        public string AddressType { get; set; }

        [Display(Name = "Address1")]
        public string Address1 { get; set; }
    
        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public int? RegionId { get; set; }

        [Display(Name = "State Name")]
        public string RegionName { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Attention To")]
        public string AttentionTo { get; set; }

        public static implicit operator AddressViewModel(AddressModel source)
        {
            return new AddressViewModel
            {
                Address1 = source.Address1,
                Address2 = source.Address2,
                AttentionTo = source.AttentionTo,
                City = source.City,
                CountryId = source.CountryId,
                CountryName = source.CountryName,
                RegionId = source.RegionId,
                RegionName = source.RegionName,
                PostalCode = source.PostalCode
            };
        }
    }
}
