using Polling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling.Repositories.IRepositories
{
    public interface IPollRepository
    {
        IEnumerable<Poll> GetPollS();
        bool Add(Poll thePoll);
        bool Remove(int theId);
        Poll GetPoll(int theId);
    }
}
