using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Checkout.Access.BasketManagement
{
    /// <summary>
    /// Class with methods to access web API
    /// This class calls web api to add, delete and clean baskets
    /// </summary>
    class AccessService : IAccessService
    {
        /// <summary>
        /// Fetch items in current basket
        /// </summary>
        /// <returns></returns>
        public List<Item> FetchItems()
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = DataSource.ServiceUrl;
            var items = client.DownloadString("Basket/Items");

            return new List<Item>();
        }

        /// <summary>
        /// Fetches items from datasource by ctegory
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<Item> FetchItems(string category)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = DataSource.ServiceUrl;
            try
            {
                var response = client.DownloadString("Show/Items");
                return JsonConvert.DeserializeObject<List<Item>>(response);
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message);
            }
        }
        
        /// <summary>
        /// Adds item into basket
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(Item item)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = DataSource.ServiceUrl;
            try
            {
                var response = client.UploadString("Basket/Items/add", "PUT", JsonConvert.SerializeObject(item));
                var parsed = JsonConvert.DeserializeObject<Item>(response);
                //True if returned and request id is same
                return parsed.Id == item.Id;
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message);
            }
        }
        
        /// <summary>
        /// Removes item from basket
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = DataSource.ServiceUrl;
            try
            {
                var response = client.UploadString("Basket/Items/remove", "PUT", id.ToString());
                return JsonConvert.DeserializeObject<bool>(response);
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message);
            }
        }

        /// <summary>
        /// Cleans complete basket
        /// </summary>
        /// <returns></returns>
        public bool Clean()
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.BaseAddress = DataSource.ServiceUrl;
            try
            {
                var response = client.UploadString("Basket/Items/clean", "Delete");
                return JsonConvert.DeserializeObject<bool>(response);
            }
            catch (Exception ex)
            {
                throw new WebException(ex.Message);
            }
        }
    }
}
