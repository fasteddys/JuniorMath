﻿using JuniorMath.ApplicationCore.Entities.StudentAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JuniorMath.ApplicationCore.DTOs.StudentExaminationPaperModel
{
    public class StudentExaminationPaperModel : IResultable<StudentExaminationPaper, StudentExaminationPaperModel>
    {
        public int Id { get; set; }
        public int ExaminationPaperId { get; set; }
        public string ExaminationPaperName { get; set; }
        public string ExaminationPaperDescription { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool Active { get; set; }
        public int? TotalMarks { get; set; }
        public bool Submitted { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public List<StudentExaminationPaperQuestionAnswerModel>
            StudentExaminationPaperQuestionAnswers
        { get; set; }

        public Expression<Func<StudentExaminationPaper, StudentExaminationPaperModel>> CreateResult()
        {
            return m => new StudentExaminationPaperModel
            {
                Id = m.Id,
                ExaminationPaperId = m.ExaminationPaperId,
                ExaminationPaperName = m.ExaminationPaperIdNavigation.Name,
                ExaminationPaperDescription = m.ExaminationPaperIdNavigation.Description,
                Notes = m.Notes,
                CreatedDate = m.CreatedDate,
                CreatedBy = m.CreatedBy,
                Active = m.Active,
                TotalMarks = m.TotalMarks,
                Submitted = m.Submitted,
                SubmittedDate = m.SubmittedDate
            };
        }

        public static implicit operator StudentExaminationPaperModel(StudentExaminationPaper source)
        {
            if (source != null)
            {
                return new StudentExaminationPaperModel
                {
                    Id = source.Id,
                    ExaminationPaperId = source.ExaminationPaperId,
                    ExaminationPaperName = source.ExaminationPaperIdNavigation.Name,
                    ExaminationPaperDescription = source.ExaminationPaperIdNavigation.Description,
                    Notes = source.Notes,
                    CreatedDate = source.CreatedDate,
                    CreatedBy = source.CreatedBy,
                    Active = source.Active,
                    TotalMarks = source.TotalMarks,
                    Submitted = source.Submitted,
                    SubmittedDate = source.SubmittedDate
                };
            }

            return null;
        }

        public static implicit operator StudentExaminationPaper(StudentExaminationPaperModel source)
        {
            if (source != null)
            {
                return new StudentExaminationPaper
                {
                    Id = source.Id,
                    ExaminationPaperId = source.ExaminationPaperId,
                    Notes = source.Notes,
                    CreatedDate = source.CreatedDate,
                    CreatedBy = source.CreatedBy,
                    Active = source.Active,
                    TotalMarks = source.TotalMarks,
                    Submitted = source.Submitted,
                    SubmittedDate = source.SubmittedDate
                };
            }

            return null;
        }
    }
}