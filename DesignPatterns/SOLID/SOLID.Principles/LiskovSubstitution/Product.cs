namespace SOLID.Principles.LiskovSubstitution
{
    /// <summary>
    /// Pattern: Tell, don't ask.
    /// </summary>
    public class Product
    {
        protected double Discount = 10;

        public virtual double GetDiscount() => Discount;
    }
}
