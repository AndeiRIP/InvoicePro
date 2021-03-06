﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicePro.Models
{
    public class Store
    {
        public Guid StoreId { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Name")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zip Code Required")]
        [Display(Name = "Zip Code")]
        public string CP { get; set; }

        [Required(ErrorMessage = "City Required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Contact Person Required")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [Display(Name = "Phone")]
        public string Phone1 { get; set; }

        [Required(ErrorMessage = "Mobile Required")]
        [Display(Name = "Mobile")]
        public string Phone2 { get; set; }

        public string Fax { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }
        public string Notes { get; set; }
        //public virtual ICollection<Invoices> {get; set;} 
    }
}
