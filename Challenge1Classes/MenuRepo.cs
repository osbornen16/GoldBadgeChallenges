using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Classes
{
    public class MenuRepo
    {
        private readonly List<Menu> _MenuItems = new List<Menu>();
        public bool AddToMenu(Menu item)
        {
            int startingCount = _MenuItems.Count;
            _MenuItems.Add(item);
            bool success = (_MenuItems.Count > startingCount) ? true : false;
            return success;
        }
        public bool RemoveFromMenu(Menu item)
        {
            bool result = _MenuItems.Remove(item);
            return result;
        }
        public List<Menu> ViewMenu()
        {
            return _MenuItems;
        }
        public Menu GetItemByNumber(int userInput)
        {
            foreach (Menu item in _MenuItems)
            {
                if (item.Number == userInput)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
