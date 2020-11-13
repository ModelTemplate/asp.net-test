using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MVCWebApp.Models
{
    /// <summary>
    /// Representing an item that is loaned to someone.
    /// </summary>
    public class Item
    {
        public int ID { get; set; }     // auto-incremented by SQL database
        public string Name { get; set; }
        public IdentityUser Owner { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public float DepreciationRate { get; set; }
        public ICollection<Item> Items { get; set; }

        public Item(string name, string description, float cost, float depreciationRate)
        {
            if (cost < 0 || depreciationRate < 0)
            {
                throw new ArgumentException("Item cost, and depreciation rate cannot be a negative value.");
            }
            else if (name == "")
            {
                throw new ArgumentException("Must put in item name.");
            }
            Name = name;
            Description = description;
            Cost = cost;
            DepreciationRate = depreciationRate;
        }

        public Item()
        {
            Name = null;
            Owner = null;
            Description = null;
            Cost = -1;
            DepreciationRate = -1;
        }
    }
}
