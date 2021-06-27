using System;

namespace BusyBeaShoppingListTest
{
    public class CatalogItem
    {

        public Guid ItemGuid { get; private set; }
        public string ItemName { get; set; }
        public CategoryEnum ItemCategory { get; set; }

        public CatalogItem()
        {
            ItemGuid = Guid.NewGuid();
        }

        public CatalogItem(string itemName, CategoryEnum itemCategory)
        {
            ItemCategory = itemCategory;
            ItemName = itemName;
            ItemGuid = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{ItemGuid}: {ItemName}; {ItemCategory}";
        }
    }
}