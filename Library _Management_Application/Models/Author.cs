using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library__Management_Application.Models
{
    public class Author : BaseEntity
    {
        public string? Name { get; set; }
        public List<AuthorBook>? AuthorBooks { get; set; }
    }
}
