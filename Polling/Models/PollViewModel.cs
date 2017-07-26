using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polling.Models
{
    public class PollViewModel
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}