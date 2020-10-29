using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            ID = id;
            Name = name;
            Description = description;
            Cost = cost;
            DepreciationRate = depreciationRate;
        }

        public Item()
        {
            ID = 0;
            Name = "Placeholder name";
            Description = "Placeholder description";
            Cost = 0;
            DepreciationRate = 0;
        }

        public ICollection<Item> Items { get; set; }
    }
}
