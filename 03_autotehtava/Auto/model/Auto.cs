using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class Auto
    {
        public int Id {  get; set; }
        public decimal Hinta { get; set; }
        public DateTime RekisteriPaivamaara { get; set; }
        public decimal MoottorinTilavuus { get; set; }
        public int Mittarilukema {  get; set; }
        public int AutonMerkkiId {  get; set; }
        public int AutonMalliId { get; set; }
        public int VariId { get; set; }
        public int PolttoaineId { get; set; }
    }
}
