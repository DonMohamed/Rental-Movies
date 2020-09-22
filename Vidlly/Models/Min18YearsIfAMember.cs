using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer)validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == MembershipType.PayAsYouGo|| customer.MemberShipTypeId == MembershipType.Unknown)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is Required.");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age > 18) ? ValidationResult.Success
                : new ValidationResult("Customer Should be at least 18 years old to go on a membership.");
        }
    }
}