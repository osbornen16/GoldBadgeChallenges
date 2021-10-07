using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Classes
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _Queue = new Queue<Claim>();
        public bool AddNewClaimToQueue(Claim claim)
        {
            int startingCount = _Queue.Count;
            _Queue.Enqueue(claim);
            bool wasAdded = (_Queue.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public Claim DequeueFromQueue()
        {
            return _Queue.Dequeue();
        }
        public Queue<Claim> ViewQueue()
        {
            return _Queue;
        }
        public Claim ViewTopClaim()
        {
           return _Queue.First();
        }
        public int CountQueueItems()
        {
            return _Queue.Count();
        }
        public Claim ViewByClaimID(int claimID)
        {
            foreach (Claim claim in _Queue)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
