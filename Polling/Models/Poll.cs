using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Polling.Models
{
    public class Poll
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}