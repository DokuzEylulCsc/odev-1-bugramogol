using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    abstract class Asker
    {
        public static Random rnd = new Random();
        public double rnd_number;
        private int can;
        private bool hayattami;
        private int saldirialani;
        private Bolge koordinat;
        public Bolge Koordinat { get { return koordinat; } }

        
        public Asker()
        {
            can = 100;
            hayattami = true;
            koordinat = new Bolge();
            koordinat.Bos = false;
        }

        public void oldur()
        {
            hayattami = false;
            this.koordinat.Bos = true;
            this.can = 0;
        }
        public int Saldirialani
        {
            get
            {
                return saldirialani ;
            }
            set
            {
                saldirialani = value;
            }
        }
        public int Can
        {
            get
            {
                return can;
            }
            set
            {
                can=value;
            }
        }
        public bool Hayattami
        {
            get
            {
                return hayattami;
            }
            set
            {
                hayattami = value;
            }
        }
        
        // ..... //

        //Abstract sınıfların implementasyonları çoçuk sınıflarda gerçekleştirilmelidir.
        public abstract void HaraketEt();

        public abstract void Bekle();

        public abstract void AtesEt(Asker x);

        // ..... //

    }
}
