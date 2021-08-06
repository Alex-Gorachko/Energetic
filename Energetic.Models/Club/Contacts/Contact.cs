using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Energetic.Models.Club.Contacts
{
    public class Contact
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}