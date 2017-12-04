using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Checkout.Access.BasketManagement
{
    public class DataSource
    {
        public const string Basket = "CurrentBasket";
        public const string AllFromDataSource = "FilterFromDataSource";
        public static string ServiceUrl = ConfigurationSettings.AppSettings["BasketManagementService"];
    }
}
