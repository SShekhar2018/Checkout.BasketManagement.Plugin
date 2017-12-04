using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Access.BasketManagement
{
    interface IAccessService
    {
        List<Item> FetchItems();
        List<Item> FetchItems(string category);

        bool Add(Item request);
        bool Remove(int id);
        bool Clean();
    }
}
