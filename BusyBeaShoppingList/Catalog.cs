using System;
using System.Collections.Generic;
using System.Linq;


namespace BusyBeaShoppingListTest
{
    public class Catalog
    {

        public Guid CatalogId { get; private set; }
        public Guid UserId { get; private set; }

        public List<CatalogItem> ItemList = new List<CatalogItem>();


        public Catalog(Guid userId)
        {
            UserId = userId;
            CatalogId = Guid.NewGuid();
        }

        public void AddItem(CatalogItem catalogItem)
        {
            ItemList.Add(catalogItem);
        }

        public CatalogItem GetItemByName(string ItemName)
        {
            CatalogItem item = null;

            return ItemList.Where(x => x.ItemName == ItemName).ToList()[0];
            //foreach (CatalogItem catalogItem in ItemList)
            //{
            //    if (catalogItem.ItemName == ItemName) return catalogItem;
            //}
            //return item;
        }

        public bool DeleteItem(CatalogItem item)
        {
            return ItemList.Remove(item);
        }

        public List<CatalogItem> filterListByCategory(CategoryEnum fruitsVegitables)
        {
            return ItemList.Where(x => x.ItemCategory == fruitsVegitables).ToList();
        }
    }
}