using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SignUp.Models
{
    public class Activity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Topic + " ( " + this.Description + " ) ";
        }

    }
}
