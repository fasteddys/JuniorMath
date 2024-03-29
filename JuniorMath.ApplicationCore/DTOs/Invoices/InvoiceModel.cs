﻿using JuniorMath.ApplicationCore.Entities.InvoiceAggregate;
using JuniorMath.ApplicationCore.Interfaces.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using JuniorMath.ApplicationCore.DTOs.Common;

namespace JuniorMath.ApplicationCore.DTOs.Invoices
{
    
    public class InvoiceModel : IResultable<Invoice, InvoiceModel>
    {

        public int InvoiceId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal Balance { get; set; }
        public int InvoiceStatus { get; set; }
        public int PaymentStatus { get; set; }
        public string OrderPaymentStatus { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateUTC { get; set; }
        public int? UpdatedBy { get; set; }
        public bool ReOccouring { get; set; }
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public int? DisplayId { get; set; }
        public string EncryptId { get; set; }
        public string ImageUrl { get; set; }
        public AddressModel PatientAddress { get; set; }
        public AddressModel ClinicAddress { get; set; }
        public List<InvoiceItemModel> InvoiceItems { get; set; }
        public List<InvoicePaymentModel> InvoicePayments { get; set; }
        
        public InvoiceModel()
        {
            InvoiceItems = new List<InvoiceItemModel>();
            InvoicePayments = new List<InvoicePaymentModel>();
        }

        public Expression<Func<Invoice, InvoiceModel>> CreateResult()
        {
            return m => new InvoiceModel
            {
                AmountPaid = m.AmountPaid,
                ClinicId = m.ClinicId,
                CreatedBy = m.CreatedBy,
                DiscountTotal = m.DiscountTotal,
                DoctorId = m.DoctorId,
                DoctorName = m.Doctor != null ? m.Doctor.FirstName + " " + m.Doctor.LastName : string.Empty,
                InvoiceDate = m.InvoiceDate,
                InvoiceId = m.Id,
                InvoiceStatus = m.InvoiceStatus,
                Note = m.Note,
                PatientId = m.PatientId,
                DisplayId = m.DisplayId,
                EncryptId = m.EncryptId,
                PatientName = m.Patient != null ? m.Patient.FirstName + " " + m.Patient.LastName : string.Empty,
                PatientEmail = m.Patient != null ? m.Patient.Email : string.Empty,
                PaymentStatus = m.PaymentStatus,
                ReOccouring = m.ReOccouring,
                Subtotal = m.Subtotal,
                TaxTotal = m.TaxTotal,
                Total = m.Total,
                UpdatedBy = m.UpdatedBy,
                UpdatedDateUTC = m.UpdatedDateUtc,
                ClinicName = m.Clinic.Name,
                ClinicAddress = (m.Clinic.Address != null) ? m.Clinic.Address : null,
                PatientAddress = (m.Patient.Address != null) ? m.Patient.Address : null,
                InvoiceItems = m.InvoiceItem.Select(p => (InvoiceItemModel)p).ToList(),
                InvoicePayments = m.InvoicePayment.Select(p => (InvoicePaymentModel)p).ToList()
            };
        }

        public static implicit operator InvoiceModel(Invoice source)
        {
            return new InvoiceModel
            {
                AmountPaid = source.AmountPaid,
                ClinicId = source.ClinicId,
                CreatedBy = source.CreatedBy,
                DiscountTotal = source.DiscountTotal,
                DoctorId = source.DoctorId,
                DoctorName = source.Doctor != null ? source.Doctor.FirstName + " " + source.Doctor.LastName : string.Empty,
                InvoiceDate = source.InvoiceDate,
                InvoiceId = source.Id,
                DisplayId = source.DisplayId,
                EncryptId = source.EncryptId,
                InvoiceStatus = source.InvoiceStatus,
                Note = source.Note,
                PatientId = source.PatientId,
                PatientName = source.Patient != null ? source.Patient.FirstName + " " + source.Patient.LastName : string.Empty,
                PatientEmail = source.Patient != null ? source.Patient.Email : string.Empty,
                PaymentStatus = source.PaymentStatus,
                ReOccouring = source.ReOccouring,
                Subtotal = source.Subtotal,
                TaxTotal = source.TaxTotal,
                Total = source.Total,
                Balance = source.Total - source.AmountPaid,
                OrderPaymentStatus = source.Total == source.AmountPaid?"PAID": source.AmountPaid ==0 ? "NOT PAID":"PARTIALLY PAID",
                UpdatedBy = source.UpdatedBy,
                UpdatedDateUTC = source.UpdatedDateUtc,
                ClinicName = source.Clinic.Name,
                ClinicAddress = (source.Clinic.Address != null) ? source.Clinic.Address : null,
                PatientAddress = (source.Patient.Address != null)? source.Patient.Address: null,
                InvoiceItems = source.InvoiceItem.Select(p => (InvoiceItemModel)p).ToList(),
                InvoicePayments = source.InvoicePayment.Select(p => (InvoicePaymentModel)p).ToList()
            };
        }

        public static implicit operator Invoice(InvoiceModel source)
        {
            return new Invoice
            {
                AmountPaid = source.AmountPaid,
                ClinicId = source.ClinicId,
                CreatedBy = source.CreatedBy,
                DiscountTotal = source.DiscountTotal,
                DoctorId = source.DoctorId,
                InvoiceDate = source.InvoiceDate,
                Id = source.InvoiceId,
                DisplayId = source.DisplayId,
                EncryptId = source.EncryptId,
                InvoiceStatus = source.InvoiceStatus,
                Note = source.Note,
                PatientId = source.PatientId,
                PaymentStatus = source.PaymentStatus,
                ReOccouring = source.ReOccouring,
                Subtotal = source.Subtotal,
                TaxTotal = source.TaxTotal,
                Total = source.Total,
                UpdatedBy = source.UpdatedBy,
                UpdatedDateUtc = source.UpdatedDateUTC,
                InvoiceItem = source.InvoiceItems.Select(p => (InvoiceItem)p).ToList(),
                InvoicePayment = source.InvoicePayments.Select(p => (InvoicePayment)p).ToList()
            };
        }
    }
}
