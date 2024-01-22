namespace SOLID.Principles.LiskovSubstitution
{
    public class OnlineProduct : Product
    {
        public void ApplyExtraDiscount()
        {
            Discount = Discount * 1.5;
        }

        public override double GetDiscount()
        {
            ApplyExtraDiscount();
            return Discount;
        }
    }
}
