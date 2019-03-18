using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker
    {
        public Er()
        {
            Saldirialani = 1;
        }
        
        public override void AtesEt(Asker x)
        {
        rnd_number = rnd.NextDouble();
            //if(this.Koordinat.X-)
            if (rnd_number < 0.5)
            {
                x.Can -= 5;
                Console.Write(" --->5 hasar vurdu \n");
            }
            else if(rnd_number>=0.5&& rnd_number < 0.8)
            {
                x.Can -= 10;
                Console.Write("--->10 hasar vurdu \n");
            }
            else
            {
                x.Can -= 15;
                Console.Write("--->15 hasar vurdu \n");
            }
            if (x.Can <= 0)
            {
                x.oldur();
            }
        }

        // ..... //
        public override void Bekle()
        {
            
        }

        public override void HaraketEt()
        {
            rnd_number = rnd.NextDouble();
            
            if (rnd_number < 0.5)
            {
                this.Koordinat.Y++;
                if (this.Koordinat.Y > 15) { 
                    this.Koordinat.Y--;
                    this.Koordinat.X--;
                }
                if (this.Koordinat.X < 0)
                    this.Koordinat.X++;
                    this.Koordinat.Y--;
            }
            else
            {
                this.Koordinat.Y--;
                if (this.Koordinat.Y < 0)
                {
                    this.Koordinat.Y++;
                    this.Koordinat.X++;
                }
                if (this.Koordinat.X > 15)
                {
                    this.Koordinat.X--;
                    this.Koordinat.Y++;
                }
            }
        }
    }
}
