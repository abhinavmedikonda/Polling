using Polling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.Repositories.IRepositories
{
    public interface IVoteRepository
    {
        bool Add(Vote theVote);
        bool Remove(int theId);
        Vote GetVoteByItemId(int theItemId);
    }
}
