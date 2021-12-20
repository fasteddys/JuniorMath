﻿using JuniorMath.ApplicationCore.DTOs.Exam;
using JuniorMath.ApplicationCore.DTOs.StudentExam;
using JuniorMath.Web.ViewModels.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JuniorMath.Web.ViewModels.Exam
{
    public class ExamViewModel
    {
        [Display(Name = "Exam Id")]
        public int ExamId { get; set; }
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [Display(Name = "Teacher")]
        public string Teacher { get; set; }
        [Display(Name = "Status")]
        public bool Active { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

        public static implicit operator ExamViewModel(ExamModel source)
        {
            return new ExamViewModel
            {
                ExamId = source.Id,
                CreatedBy = source.CreatedBy,
                Active = source.Active,
                CreateDate = source.CreatedDate,
                Description = source.Description,
                ExamName = source.Name,
                Teacher = source.Teacher,
                Questions = source.Questions.Select(p => (QuestionViewModel)p).ToList()
            };
        }
    }
}