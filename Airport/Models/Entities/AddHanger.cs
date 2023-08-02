using Airport.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models.Entities
{
    public class AddHanger
    {
        public AddHanger() { }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Enter alphabets and spaces")]
        public string HangerLocation { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Capacity must contain only numbers.")]
        public int HangerCapacity { get; set; }
        [Required(ErrorMessage ="*Required")]
        public string ManagerName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number.(ddd-dd-dddd)")]
        public string SocialSecuirtyNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [CustomDateValidation(ErrorMessage = "Date of Birth should be less than today's date.")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[1-9]\d{9}$", ErrorMessage = "Please enter a valid 10-digit mobile number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string HouseNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City should contain only alphabets and space.")]
        public string City { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "State should contain only alphabets and space.")]
        public string State { get; set; }

        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Country should contain only alphabets and space.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "*Required")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "PIN Number should contain exactly 7 digits.")]
        public string PinNo { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string AddressLine { get; set; }
    }
}