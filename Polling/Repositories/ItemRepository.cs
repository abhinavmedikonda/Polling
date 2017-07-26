using Polling.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polling.Models;

namespace Polling.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext theContext)
        {
            this._context = theContext;
        }

        public bool Add(Item theItem)
        {
            this._context.Items.Add(theItem);

            return this._context.SaveChanges() == 1;
        }

        public List<Item> GetItemSByPollId(int thePollId)
        {
            return this._context.Items.Where(x => x.PollId == thePollId).ToList();
        }
    }
}