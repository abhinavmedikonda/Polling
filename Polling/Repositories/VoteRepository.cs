using Polling.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polling.Models;

namespace Polling.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private ApplicationDbContext _context;

        public VoteRepository(ApplicationDbContext theContext)
        {
            this._context = theContext;
        }

        public bool Add(Vote theVote)
        {
            this._context.Votes.Add(theVote);

            return this._context.SaveChanges() == 1;
        }

        public Vote GetVoteByItemId(int theItemId, string theUserId)
        {
            return this._context.Votes.SingleOrDefault(x => x.ItemId == theItemId && x.AspNetUserId == theUserId);
        }

        public bool Remove(int theId, string theUserId)
        {
            this._context.Votes.Remove(this._context.Votes.SingleOrDefault(x => x.ItemId == theId && x.AspNetUserId == theUserId));

            return this._context.SaveChanges() == 1;
        }
    }
}