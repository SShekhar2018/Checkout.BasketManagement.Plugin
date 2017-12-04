using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Access.BasketManagement
{
    public class ManageRequest
    {
        public ManageRequest()
        {
            this.ItemInfo = new Item();
        }

        public Item ItemInfo { get; set; }

        internal Operation OperationType { get => operationType; set => operationType = value; }

        private Operation operationType;
    }
}
