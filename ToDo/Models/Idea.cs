using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class Idea
    {
        // Id property for user Id
        public int Id { get; set; }

        // this property is for title of idea
        public string Title { get; set; }

        // this property is for more details
        public string Description { get; set; }
        
        // what is the category of this idea
        public string Category { get; set; }

        // whom this idea belongs to (this one reffers to user ID which can find in database)
        public string UserId { get; set; }
    }
}