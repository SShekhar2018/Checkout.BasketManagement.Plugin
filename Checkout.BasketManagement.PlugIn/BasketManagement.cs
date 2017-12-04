using Checkout.BasketManagement.PlugIn;
using System;
using System.Collections.Generic;

namespace Checkout.Access.BasketManagement
{
    public class BasketManagement
    {
        private IAccessService AccessService { get; set; }

        public BasketManagement()
        {
            this.AccessService = new AccessService();
        }

        /// <summary>
        /// Method to manage actions on basket
        /// Add items to basket or removes item from basket
        /// or clean the complete basket
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool Manage(ManageRequest request)
        {
            switch (request.OperationType)
            {
                case Operation.Add:
                    return this.AccessService.Add(request.ItemInfo);
                case Operation.Remove:
                    return this.AccessService.Remove(request.ItemInfo.Id);
                case Operation.Clean:
                    return this.AccessService.Clean();
                default:
                    throw new InvalidOperationException("Invalid parameter");
            }
        }

        /// <summary>
        /// It is one method which shows items from basket or list 
        /// of all items in db
        /// </summary>
        /// <param name="source">From which data should be fetched i.e.CurrentBasket or all Data</param>
        /// <param name="category">Category (Electronic, FootWear) of which data needs to be fetched</param>
        /// <returns></returns>
        public List<Item> Fetch(string source, string category)
        {
            switch (source)
            {
                case DataSource.Basket:
                    ItemList.Items = this.AccessService.FetchItems();
                    break;
                case DataSource.AllFromDataSource:
                default:
                    ItemList.Items = this.AccessService.FetchItems(category);
                    break;
            }

            return ItemList.Items;
        }
    }
}
