using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppTest.Models
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
        public float DepreciationRate { get; set; } = 0;

        public Item(int id = 0, string name = "Placeholder name", string description = "Placeholder description", 
                float cost = 0, float depreciationRate = 0)
        {
            ID = id;
            Name = name;
            Description = description;
            Cost = cost;
            DepreciationRate = depreciationRate;
        }
    }
}
