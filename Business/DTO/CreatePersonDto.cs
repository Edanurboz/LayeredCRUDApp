using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class CreatePersonDto
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public long Tc { get; set; }
        public int Dogumyili { get; set; }
    }
}
