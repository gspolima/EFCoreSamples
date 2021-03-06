using System;
using System.Collections.Generic;

namespace EFCoreSamples
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public PlaystationPlus PlaystationPlus { get; set; }
        public List<Console> Consoles { get; set; } = new List<Console>();
        public List<Trophy> Trophies { get; set; } = new List<Trophy>();
    }
}
