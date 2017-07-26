using Polling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.Repositories.IRepositories
{
    public interface IItemRepository
    {
        bool Add(Item theItem);
        List<Item> GetItemSByPollId(int thePollId);
    }
}
