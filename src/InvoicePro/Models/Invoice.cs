using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicePro.Models
{ 
    public enum InvoiceState
    {
        draft = 0,
        released = 1
    }
    public class Invoice
    {
        public List<InvoiceDetails> InvoiceDetails;
        public Invoice ()
        {
            InvoiceDetails = new List<InvoiceDetails>();
        }

        public Guid InvoiceId { get; set; }

        [Display(Name = "Invoice Number")]
        public int? InvoiceNumber { get; set; }
        public InvoiceState InvoiceState { get; set; }
        public Customer Customer { get; set; }
        public Store Store { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Created")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Advance Payment (%)")]
        [Range(0.00, 100.0, ErrorMessage = "Value must be between 0.00 and 100.0")]
        public decimal AdvancePaymentTax
        {
            get
            {
                return InvoiceDetails == null ? 0 : TotalWithVAT * (AdvancePaymentTax / 100);
            }
            set { }
        }

        public bool Paid { get; set; }
        public  string User { get; set; }
        public ICollection<InvoiceDetails> Invoices { get; set; }

        [Display(Name = "VAT Amount")]
        public decimal VATAmount
        {
            get
            {
                return TotalWithVAT - NetTotal;
            }
            set { }
        }
        public decimal NetTotal {
            get
            {
                return InvoiceDetails?.Sum(i => i.Total) ?? 0;
            }
            set { }
        }
        public decimal AdvancePaymentTaxAmount { get; set; }

        [Display(Name = "Total with VAT")]
        public decimal TotalWithVAT {
            get
            {
                return InvoiceDetails?.Sum(i => i.TotalPlusVat) ?? 0;
            }
            set { }
        }

        [Display(Name = "Total to pay")]
        public decimal TotalToPay { get; set; }

    }
}
