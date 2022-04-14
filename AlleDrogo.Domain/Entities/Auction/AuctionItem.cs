using AlleDrogo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AlleDrogo.Domain.Entities.Auction
{
    public class AuctionItem : EntityBase
    {
        protected AuctionItem() { }

        public AuctionItem(string name, Category category, string description, bool isNew)
        {
            Name = name;
            Description = description;
            Category = category;
            IsNew = isNew;
        }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public Category Category { get; protected set; }

        public bool IsNew { get; protected set; }

        public virtual Auction Auction { get; protected set; }

        public int AuctionId { get; protected set; }

        public ICollection<ItemPhoto> Photos { get; protected set; }

        public void AddPhoto(ItemPhoto photo)
        {
            Photos.Add(photo);
        }
    }
}
