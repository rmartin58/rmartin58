using System;
using System.Diagnostics;

namespace BusyBeaShoppingListTest
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class ShoppingListUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; private set; }

        public ShoppingListUser()
        {
            UserId = Guid.NewGuid();
        }

        public ShoppingListUser(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            UserId = Guid.NewGuid();
        }


        public override string ToString()
        {
            return $"{UserId}: {LastName}, {FirstName}";
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}