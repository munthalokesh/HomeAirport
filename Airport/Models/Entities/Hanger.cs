using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airport.Models.Entities
{
    public class Hanger
    {
        public string HangerId { get; set; }
        public string HangerLocation { get; set; }

        public int HangerCapacity { get; set; }
    }
}