using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Classes
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _DoorAccess = new Dictionary<int, List<string>>();
        public bool CreateBadge(Badge badge)
        {
            int startingCount = _DoorAccess.Count;
            _DoorAccess.Add(badge.BadgeID, badge.AccessibleDoors);
            bool wasAdded = (_DoorAccess.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool removeBadge (int key)
        {
            bool result = _DoorAccess.Remove(key);
            return result;
        }
        public Dictionary<int, List<string>> ViewBadges()
        {
            return _DoorAccess;
        } 
        public List<string> LookUpByID(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> badge in _DoorAccess)
            {
                if (badge.Key == badgeID)
                {
                    return badge.Value;
                }
            }
            return null;
        }
    }
}
