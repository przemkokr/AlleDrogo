using AlleDrogo.Domain.Entities.Base;

namespace AlleDrogo.Domain.Entities.Item
{
    public class Item : EntityBase
    {
        // this is how should domain entity class look 

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public decimal BasePrice { get; protected set; }                

        public decimal CurrentPrice { get; protected set; }


        public Item(string name, string description, decimal basePrice)
        {
            this.Name = name;
            this.Description = description; 
            this.BasePrice = basePrice;
        }

        public void BidUp(decimal newValue)
        {
            this.CurrentPrice = newValue;
        }
    }
}
