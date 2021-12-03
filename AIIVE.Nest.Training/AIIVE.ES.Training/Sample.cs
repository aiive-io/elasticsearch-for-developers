using Nest;
using System;

namespace AIIVE.ES.NEST.Training
{
    public class Sample
    {
        public string[] Category { get; set; }

        public string Currency { get; set; }

        [PropertyName("customer_birth_date")]
        public DateTime CustomerBirthDate { get; set; }

        [PropertyName("customer_first_name")]
        public string CustomerFirstName { get; set; }

        [PropertyName("customer_full_name")]
        public string CustomerFullName { get; set; }

        [PropertyName("customer_gender")]
        public string CustomerGender { get; set; }

        public string CustomerId { get; set; }

        public string CustomerLastName { get; set; }

        public Products[] Products { get; set; }

    }
    public class Products
    {
        public decimal Price { get; set; }
    }
}