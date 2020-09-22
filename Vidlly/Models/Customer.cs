﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="please Enter Customer's Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedTonewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }





    }
}