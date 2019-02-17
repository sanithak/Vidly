﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the customers name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool isSubscribedtoNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name ="Date of Birth")]
        [Min18yrsIfaMember]
        public DateTime? Birthdate { get; set; }
    }
}