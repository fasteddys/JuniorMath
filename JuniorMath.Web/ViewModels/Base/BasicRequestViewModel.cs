﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using JuniorMath.ApplicationCore.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Base
{
    public class BasicRequestViewModel 
    {
        [Display(Name = "Success")]
        public bool Success { get; set; }
        [Display(Name = "Error Message")]
        public string ErrorMessage { get; set; }
        public Pager Pager { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int MaxPages { get; set; }

        public BasicRequestViewModel()
        {
            CurrentPage = 1;
            MaxPages = WebSiteSettings.MaxPages;
            PageSize = WebSiteSettings.PageSize;
            Pager = new Pager(0, CurrentPage, PageSize, MaxPages);
        }
    }
}
