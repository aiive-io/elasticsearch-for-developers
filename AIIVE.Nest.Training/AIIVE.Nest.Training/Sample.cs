using Nest;
using System;

namespace AIIVE.ES.NEST.Training
{
    public class Sample
    {
        public string Category { get; set; }

        public string Currency { get; set; }

        [PropertyName("customer_birth_date")]
        public DateTime CustomerBirthDate { get; set; }

        [PropertyName("customer_first_name")]
        public string CustomerFirstName { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerGender { get; set; }

        public string CustomerId { get; set; }

        public string CustomerLastName { get; set; }

        public
    }
}