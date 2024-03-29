﻿using JuniorMath.ApplicationCore.Entities.CommonAggregate;
using JuniorMath.ApplicationCore.Entities.PatientAggregate;
using JuniorMath.ApplicationCore.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorMath.ApplicationCore.Specifications.Patients
{
    public class PatientSpecification : BaseSpecification<Patient>
    {
        public PatientSpecification(int clinicId) : base()
        {
            AddCriteria(q => q.ClinicId == clinicId);
            AddInclude(b => b.Family);
            AddInclude(b => b.Address);
            AddInclude($"{nameof(Patient.Address)}.{nameof(Address.Country)}");
            AddInclude($"{nameof(Patient.Address)}.{nameof(Address.RegionNavigation)}");
        }

        public void AddfamilyId(int familyId)
        {
            AddCriteria(q => q.FamilyId == familyId);
        }

        public void AddPatientId(int patientId)
        {
            AddCriteria(q => q.Id == patientId);
        }

        public void AddFirstName(string firstName)
        {
            AddCriteria(q => q.FirstName.Contains(firstName));
        }

        public void AddLastName(string lastName)
        {
            AddCriteria(q => q.LastName.Contains(lastName));
        }
    }
}
