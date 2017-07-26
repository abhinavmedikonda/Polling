using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Polling.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}