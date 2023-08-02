using Airport.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models.Entities
{
    
        public class AddPilot
        {
            public AddPilot() { }
            [Required(ErrorMessage = "Enter Pilot Name")]
            [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Pilot Name should contain only alphabets and spaces.")]
            public string PilotName { get; set; }
            [Required(ErrorMessage = "Enter license number")]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "The license number must be exactly 10 digits.")]

            public string LicenseNo { get; set; }
            [Required(ErrorMessage = "Enter social security number")]
            [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number.")]

            public string SocialSecurityNo { get; set; }

            [Required(ErrorMessage = "Enter date of birth")]
            [CustomDateValidation(ErrorMessage = "Date of Birth should be less than today's date.")]
            public DateTime DateOfBirth { get; set; }
            [Required(ErrorMessage = "Please select a valid gender.")]
            public string Gender { get; set; }
            [Required(ErrorMessage = "Enter Mobile number")]
            [RegularExpression(@"^[1-9]\d{9}$", ErrorMessage = "Please enter a valid 10-digit mobile number")]
            public string MobileNo { get; set; }
            [Required(ErrorMessage = "Enter email address")]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
            public string EmailAddress { get; set; }

            [Required(ErrorMessage = "Enter House number")]
            public string HouseNo { get; set; }
            [Required(ErrorMessage = "City is required.")]
            [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City should contain only alphabets and space.")]
            public string City { get; set; }
            [Required(ErrorMessage = "State is required.")]
            [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State should contain only alphabets and space.")]
            public string State { get; set; }

            [Required(ErrorMessage = "Country is required.")]
            [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country should contain only alphabets and space.")]
            public string Country { get; set; }
            [Required(ErrorMessage = "PIN Number is required.")]
            [RegularExpression(@"^\d{7}$", ErrorMessage = "PIN Number should contain exactly 7 digits.")]
            public string PinNo { get; set; }
            [Required(ErrorMessage ="*Required")]
            public string AddressLine { get; set; }
        }
    }
