using System;
using System.Collections.Generic;

namespace MVCWebApp.Models
{
    /// <summary>
    /// Representing an item that is loaned to someone.
    /// </summary>
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Cost { get; set; }
        public float DepreciationRate { get; set; }

        public Item(int id, string name, string description, float cost, float depreciationRate)
        {
            if (id < 0 || cost < 0 || depreciationRate < 0)
            {
                throw new ArgumentException("Id number, item cost, and depreciation rate cannot be a negative value.");
            }
            else if (name == "")
            {
                throw new ArgumentException("Must put in item name.");
            }
            ID = id;
            Name = name;
            Description = description;
            Cost = cost;
            DepreciationRate = depreciationRate;
        }

        public Item()
        {
            ID = -1;
            Name = null;
            Description = null;
            Cost = -1;
            DepreciationRate = -1;
        }

        public ICollection<Item> Items { get; set; }
    }
}
