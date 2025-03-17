using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuggohidak
{
    class Fuggohid
    {
        public int Helyezes { get; set; }
        public string Nev { get; set; }
        public string Hely { get; set; }
        public string Orszag { get; set; }
        public int Hossza { get; set; }
        public int AtadasiEv { get; set; }

        
        public Fuggohid(string sor) 
        {
            var s = sor.Split("\t");
            Helyezes= Convert.ToInt32(s[0]);
            Nev = s[1];
            Hely = s[2];
            Orszag = s[3];
            Hossza = Convert.ToInt32(s[4]);
            AtadasiEv = Convert.ToInt32(s[5]);

        }
    }
}
