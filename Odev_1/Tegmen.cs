using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        public Tegmen()
        {
            Saldirialani = 2;
        }
        
        public override void AtesEt(Asker x)
        {
            rnd_number = rnd.NextDouble();
            if (rnd_number < 0.5)
            {
                x.Can -= 10;
                Console.Write("--->10 hasar vurdu \n");
                
            }
            else if (rnd_number >= 0.5 && rnd_number < 0.8)
            {
                x.Can -= 20;
                Console.Write("--->20 hasar vurdu \n");
            }
            else
            {
                x.Can -= 25;
                Console.Write("--->25 hasar vurdu \n");
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
        //Er Classnda daha farkli yaptım goto kullanmadan hangisi daha mantıklı emin olamadığım için Er classında farklı bir hareketmetodu var
        //goto kullanma
        public override void HaraketEt()
        {
            tekrar:
            rnd_number = rnd.NextDouble();
            if (rnd_number < 0.25)
            {
                this.Koordinat.Y++;                      //YUKARI
                if (this.Koordinat.Y > 15)
                {
                    this.Koordinat.Y--;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.25 && rnd_number < 0.5)
            {
                this.Koordinat.X++;                      //SAĞA
                if (this.Koordinat.X > 15)
                {
                    this.Koordinat.X--;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.5 && rnd_number < 0.75)
            {
                this.Koordinat.X--;                      //SOLA
                if (this.Koordinat.X <0)
                {
                    this.Koordinat.X++;
                    goto tekrar;
                }
            }
            else
            {
                this.Koordinat.Y--;                      //AŞAĞI
                if (this.Koordinat.Y < 0)
                {
                    this.Koordinat.Y++;
                    goto tekrar;
                }
            }
        }
    }
}
