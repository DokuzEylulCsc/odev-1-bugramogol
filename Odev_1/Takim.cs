using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Takim
    {
        Asker[] birlik = new Asker[7];
        bool saglam;
        string ad;

        public Asker[] Birlik { get { return birlik; } set { birlik = value; } }

        public string Ad { get { return ad; } set { ad = value; } }

        public bool Saglam{ get { return saglam; } set { saglam = value; } }
        
        public Takim()
        {
            birlik[0] = new Yuzbasi();
            birlik[1] = new Tegmen();
            birlik[2] = new Tegmen();
            birlik[3] = new Er();
            birlik[4] = new Er();
            birlik[5] = new Er();
            birlik[6] = new Er();
            saglam = true;
        }
        
        public bool kontrol()   //takimdaki herkesi kontrol eden fonksiyon eger hayatta olan olmaz ise oyun biter
        {
            int say = 0;
            for (int i = 0; i < 7; i++)
            {
                if (birlik[i].Hayattami)
                {
                    say++;
                }
            }
            if (say == 0) { 
                saglam = false;
                return saglam;
            }
            return saglam;
        }

        // ..... //
    }
}
