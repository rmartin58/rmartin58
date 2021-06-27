using System;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace BusyBeaShoppingListTest
{
    public class CatalogUnitTest
    {

        [Fact]
        public void UserShouldBeaAbleToAddItemToCatalog()
        {
            // Arragnge
            ShoppingListUser user = new ShoppingListUser();
            user.FirstName = "Bea";
            user.LastName = "Martin";
            user.UserId.Should().NotBeEmpty();
            Console.WriteLine(user.ToString());

            CatalogItem spinach = new CatalogItem("spniach", CategoryEnum.FruitsVegitables);

            Console.WriteLine(spinach.ToString());
            Catalog catalog = new Catalog(user.UserId);

            // Act
            catalog.AddItem(spinach);

            // Assert
            catalog.ItemList.Should().HaveCount(1);
        }

        [Fact]
        public void UserCanDeleteAnItemFromCatalog()
        {
            // Arragnge
            ShoppingListUser user = new ShoppingListUser("Bea", "Mogannam-Martin");
            user.UserId.Should().NotBeEmpty();
            Console.WriteLine(user.ToString());

            Catalog catalog = new Catalog(user.UserId);
            catalog.AddItem(new CatalogItem("Elysian Immortal IPA", CategoryEnum.Beverages));
            catalog.AddItem(new CatalogItem("Filet Mignon", CategoryEnum.MeatSeafood));
            catalog.ItemList.Should().HaveCount(2);

            // Act
            CatalogItem catalogItemByIndex = catalog.ItemList.GetRange(0,1)[0];
            catalogItemByIndex.ItemGuid.Should().NotBeEmpty();

            CatalogItem catalogItemByName = catalog.GetItemByName("Elysian Immortal IPA");
            catalogItemByName.Should().NotBeNull();
            catalogItemByName.ItemGuid.Should().Equals(catalogItemByIndex.ItemGuid);
            bool isItemDeleted = catalog.DeleteItem(catalogItemByName);
            isItemDeleted.Should().BeTrue();

            // Assert
            catalog.ItemList.Should().HaveCount(1);
            List<CatalogItem> itemList = catalog.ItemList;
            CatalogItem item = itemList.GetRange(0, 1)[0];
            item.ItemName.Should().Match("Filet Mignon");
        }

        [Fact]
        public void UserCanGetSublistBasedOnCategory()
        {
            // Arragnge
            ShoppingListUser user = new ShoppingListUser("Bea", "Mogannam-Martin");
            Catalog catalog = new Catalog(user.UserId);
            catalog.AddItem(new CatalogItem("Elysian Immortal IPA", CategoryEnum.Beverages));
            catalog.AddItem(new CatalogItem("Filet Mignon", CategoryEnum.MeatSeafood));
            catalog.AddItem(new CatalogItem("spniach", CategoryEnum.FruitsVegitables));
            catalog.AddItem(new CatalogItem("onions", CategoryEnum.FruitsVegitables));
            catalog.AddItem(new CatalogItem("tomatoes", CategoryEnum.FruitsVegitables));
            catalog.AddItem(new CatalogItem("potatos", CategoryEnum.FruitsVegitables));
            catalog.AddItem(new CatalogItem("watermelon", CategoryEnum.FruitsVegitables));
            catalog.ItemList.Should().HaveCount(7);
            // Act
            var fruitsVegitables = catalog.filterListByCategory(CategoryEnum.FruitsVegitables);
            // Assert
            fruitsVegitables.Should().HaveCount(5);
            fruitsVegitables.GetRange(3,1)[0].ItemName.Should().Match("potatos");
        }


    }
}


