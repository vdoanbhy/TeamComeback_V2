using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamComeback_V2.Models
{
    public enum State
    {
        AL, AK, AZ, AR, CA, CO, CT, DC, DE, FL, GA,
        HI, ID, IL, IN, IA, KS, KY, LA, ME, MD,
        MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ,
        NM, NY, NC, ND, OH, OK, OR, PA, RI, SC,
        SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
    }

    public enum Gender
    {
        Male, Female, Other
    }
    public class Member
    {
        public int ID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public Gender? Gender { get; set; }
        public string DoB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public State? State { get; set; }
        public int Zip { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Date of Last Stroke")]
        public string DateOfLastStroke { get; set; }
        public virtual ICollection<Registar> Registars { get; set; }
    }
}