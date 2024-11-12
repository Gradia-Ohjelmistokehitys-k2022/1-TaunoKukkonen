using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirjasto.Models
{
    public class Book
    {
      public int Id { get; set; }  
      public required string Name { get; set; }
      public string ISBN { get; set; }
      public int PublicationYear { get; set; }
    }
}
