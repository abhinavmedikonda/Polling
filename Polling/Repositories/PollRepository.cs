using Polling.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polling.Models;

namespace Polling.Repositories
{
    public class PollRepository : IPollRepository
    {
        private ApplicationDbContext _context;

        public PollRepository(ApplicationDbContext theContext)
        {
            this._context = theContext;
        }

        public bool Add(Poll thePoll)
        {
            this._context.Polls.Add(thePoll);

            return this._context.SaveChanges() == 1;
        }

        public Poll GetPoll(int theId)
        {
            return this._context.Polls.SingleOrDefault(x => x.Id == theId);
        }

        public IEnumerable<Poll> GetPollS()
        {
            return this._context.Polls.ToList();
        }

        public bool Remove(int theId)
        {
            this._context.Polls.Remove(this._context.Polls.SingleOrDefault(x => x.Id == theId));

            return this._context.SaveChanges() == 1;
        }
    }
}