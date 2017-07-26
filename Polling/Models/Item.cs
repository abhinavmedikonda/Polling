using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Polling.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int PollId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual Poll Poll { get; set; }
        public virtual List<Vote> Votes { get; set; }
    }
}