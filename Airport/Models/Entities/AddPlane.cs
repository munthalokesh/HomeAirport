using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Airport.Models.Entities
{
    public class AddPlane
    {
        [Required(ErrorMessage = "Manufacturer Name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Manufacturer Name should contain only alphabets and spaces.")]
        public string ManufacturerName { get; set; }



        [Required(ErrorMessage = "Registration Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Registration Number should be 10 digit numeric.")]
        public string RegistrationNo { get; set; }



        [Required(ErrorMessage = "Model Number is required.")]
       // [RegularExpression(@"^[A-Za-z0-9-]+$", ErrorMessage = "Model Number should contain only alphabets, numbers, and hyphens.")]
        public string ModelNo { get; set; }



        [Required(ErrorMessage = "Plane Name is required.")]
        //[RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Plane Name should contain only alphabets and spaces.")]
        public string PlaneName { get; set; }



        [Required(ErrorMessage = "Capacity is required.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Capacity should contain only numbers.")]
        public int Capacity { get; set; }



        [Required(ErrorMessage = "Email address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }



        [Required(ErrorMessage = "House No is required.")]
        public string HouseNo { get; set; }



        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City should contain only alphabets and spaces.")]
        public string City { get; set; }



        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "State should contain only alphabets and spaces.")]
        [Required(ErrorMessage = "State name is required.")]
        public string State { get; set; }



        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Country should contain only alphabets and spaces.")]
        [Required(ErrorMessage = "Country name is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "*Required")]
        public string AddressLine { get; set; }
    

    [Required(ErrorMessage = "Pin No is required.")]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "Pin No should contain exactly 7 digits.")]
        public string PinNo { get; set; }
    }
}