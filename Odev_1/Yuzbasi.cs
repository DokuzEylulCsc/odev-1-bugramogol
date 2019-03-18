using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Yuzbasi : Asker
    {
        public Yuzbasi()
        {
            Saldirialani = 3;
        }
        
        public override void AtesEt(Asker x)
        {
            rnd_number = rnd.NextDouble();
            if (rnd_number < 0.5)
            {
                x.Can -= 15;
                Console.Write("---> 15 hasar vurdu \n");
            }
            else if (rnd_number >= 0.5 && rnd_number < 0.8)
            {
                x.Can -= 25;
                Console.Write("---> 25 hasar vurdu \n");
            }
            else
            {
                x.Can -= 40;
                Console.Write("---> 40 hasar vurdu \n");
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
            tekrar:
            rnd_number = rnd.NextDouble();
            if (rnd_number < 0.125)
            {
                this.Koordinat.Y++;                     //YUKARI
                if (this.Koordinat.Y > 15)
                {
                    this.Koordinat.Y--;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.125 && rnd_number < 0.25)
            {
                this.Koordinat.Y++; this.Koordinat.X++;       //SAĞ ÜST ÇAPRAZ
                if (this.Koordinat.Y > 15 || this.Koordinat.X>15)
                {
                    this.Koordinat.Y--; this.Koordinat.X--;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.25 && rnd_number < 0.375)
            {
                this.Koordinat.Y++; this.Koordinat.X--;       //SOL ÜST ÇAPRAZ
                if (this.Koordinat.Y > 15 || this.Koordinat.X < 0)
                {
                    this.Koordinat.Y--; this.Koordinat.X++;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.375 && rnd_number < 0.5)
            {
                this.Koordinat.X--;                      //SOL
                if (this.Koordinat.X < 0)
                {
                    this.Koordinat.X++;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.5 && rnd_number < 0.625)
            {
                this.Koordinat.X++;                      //SAĞ
                if (this.Koordinat.Y > 15)
                {
                    this.Koordinat.Y--;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.625 && rnd_number < 0.750)
            {
                this.Koordinat.Y--; this.Koordinat.X--;       //SOL ALT
                if (this.Koordinat.Y < 0 || this.Koordinat.X < 0)
                {
                    this.Koordinat.Y++; this.Koordinat.X++;
                    goto tekrar;
                }
            }
            else if (rnd_number >= 0.750 && rnd_number < 0.875)
            {
                this.Koordinat.Y--; this.Koordinat.X++;       //SAĞ ALT
                if (this.Koordinat.Y < 0 || this.Koordinat.X > 15)
                {
                    this.Koordinat.Y++; this.Koordinat.X--;
                    goto tekrar;
                }
            }
            else
            {
                this.Koordinat.Y--;                      //AŞAĞI
                if (this.Koordinat.Y < 0 )
                {
                    this.Koordinat.Y++;
                    goto tekrar;
                }
            }
        }
    }
}
