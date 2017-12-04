using Checkout.Access.BasketManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.BasketManagement.PlugIn
{
    /// <summary>
    /// TO have in memory for easy adding deleting items
    /// </summary>
    public static class ItemList
    {
        public static List<Item> Items { get; set; }

        static ItemList()
        {
            Items = new List<Item>();
        }
    }
}
