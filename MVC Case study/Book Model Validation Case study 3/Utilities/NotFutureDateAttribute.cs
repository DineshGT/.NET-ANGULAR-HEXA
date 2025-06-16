using System;
using System.ComponentModel.DataAnnotations;

namespace Book_Model_Validation_Case_study.Utilities
{
    public class NotFutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Today;
            }
            return false;
        }
    }
}
