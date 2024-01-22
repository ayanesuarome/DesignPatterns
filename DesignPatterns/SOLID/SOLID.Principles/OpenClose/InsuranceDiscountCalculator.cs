namespace SOLID.Principles.Single
{
    public class InsuranceDiscountCalculator
    {
        public int calculateDiscount(HealthInsuranceCustomer customer)
        {
            if(customer.IsLoyalCustomer)
            {
                return 10;
            }

            return 0;
        }

        public int calculateDiscount(VehicleInsuranceCustomer customer)
        {
            if (customer.IsLoyalCustomer)
            {
                return 10;
            }

            return 0;
        }

        // Fixed 1
        public int calculateDiscount(ICustomer customer)
        {
            if (customer.IsLoyalCustomer)
            {
                return 20;
            }

            return 0;
        }
    }
}
