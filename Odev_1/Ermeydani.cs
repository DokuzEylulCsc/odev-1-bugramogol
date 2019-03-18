using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Ermeydani
    {
        Bolge[,] harita = new Bolge[16, 16];
        Takim[] takim = new Takim[2];
        Random rnd1 = new Random();
        private double rnd_number;
        private int oyuncuno;
        public Bolge[,] Harita { get { return harita; } set { harita = value; } }
        
        public Ermeydani()
        {
                //meydan oluştur
            int say1, say2;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    harita[i, j] = new Bolge();
                    harita[i, j].X = i;
                    harita[i, j].Y = j;
                }
            }
                //takim 1 oluştur
            takim[0] = new Takim(); takim[0].Ad = "A";
            foreach(Asker a in takim[0].Birlik)
            {
                geri:
                say1 = rnd1.Next(0, 5);
                say2 = rnd1.Next(0, 5);
                if (harita[say1, say2].Bos)
                {
                    a.Koordinat.X = say1;
                    a.Koordinat.Y = say2;
                    harita[say1, say2].Bos = false;
                }
                else goto geri;
            }
                //takim 2 oluştur
            takim[1] = new Takim(); takim[1].Ad = "B";
            foreach (Asker a in takim[1].Birlik)
            {
                geri:
                say1 = rnd1.Next(10, 15);
                say2 = rnd1.Next(10, 15);
                if (harita[say1, say2].Bos)
                {
                    a.Koordinat.X = say1;
                    a.Koordinat.Y = say2;
                    harita[say1, say2].Bos = false;
                }
                else goto geri;
            }
        }
       
        public void Basla()
        {
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 7; j++)
                Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} \t Can ---> {3} --> kordinatlari({4},{5})", i+1, j + 1, takim[i].Birlik[j].GetType().Name, takim[i].Birlik[j].Can, takim[i].Birlik[j].Koordinat.X, takim[i].Birlik[j].Koordinat.Y);
                Console.WriteLine("--------------------------------------------------------------------");
            }
            int k=1;
            bool vurdu = false;
            bool deneme = true;
            while (deneme)
            {
                for(int i = 0; i < 2; i++)
                {
                    deneme = takim[i].kontrol();
                }
                
                for(int i = 0; i < 2; i++)
                {
                    
                        if (i == 0) k = 1;
                        if (i == 1) k = 0;
                    ////////////////////////////////////////////////////////////////
                    tekrar:
                    oyuncuno = rnd1.Next(0, 7);
                    if (!takim[i].Birlik[oyuncuno].Hayattami) { 
                        goto tekrar;
                    }
                    //Seçilen asker hayatta ise devam değilse geri dön
                    else
                    {
                        rnd_number = rnd1.NextDouble();
                        if (rnd_number < 0.2)   //HAREKET ETME
                        {
                            takim[i].Birlik[oyuncuno].HaraketEt();
                            Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} --->kordinatlari({3},{4}) ---> {5} Cani var -----> Hareket etti", takim[i].Ad, oyuncuno + 1, takim[i].Birlik[oyuncuno].GetType().Name,
                                takim[i].Birlik[oyuncuno].Koordinat.X, takim[i].Birlik[oyuncuno].Koordinat.Y, takim[i].Birlik[oyuncuno].Can);
                            //Console.ReadKey();
                        }

                        else if (rnd_number >= 0.2 && rnd_number < 0.8)    //ATEŞ ETME
                        {
                            vurdu = false;
                            for (int j = 0; j < 7; j++)
                            {
                                if (!takim[k].Birlik[j].Hayattami)
                                    j++;
                                else { 
                                //Uzaklığa göre saldirilacak ilk hedef bulunur
                                    if (takim[i].Birlik[oyuncuno].Saldirialani > Math.Sqrt((Math.Pow(takim[i].Birlik[oyuncuno].Koordinat.X, 2) - Math.Pow(takim[k].Birlik[j].Koordinat.X, 2)) + (Math.Pow(takim[i].Birlik[oyuncuno].Koordinat.Y, 2) - Math.Pow(takim[k].Birlik[j].Koordinat.Y, 2))))
                                    {
                                        Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} ---> kordinatlari({3},{4}) -->{5} Cani var ----->Ateş Etti  ", takim[i].Ad, oyuncuno + 1, takim[i].Birlik[oyuncuno].GetType().Name,
                                            takim[i].Birlik[oyuncuno].Koordinat.X, takim[i].Birlik[oyuncuno].Koordinat.Y, takim[i].Birlik[oyuncuno].Can);
                                        //ATES ETME
                                        takim[i].Birlik[oyuncuno].AtesEt(takim[k].Birlik[j]);
                                        
                                        Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} ---> kordinatlari({3},{4}) Vuruldu {5} Cani kaldi ", takim[k].Ad, j + 1, takim[k].Birlik[j].GetType().Name,
                                            takim[k].Birlik[j].Koordinat.X, takim[k].Birlik[j].Koordinat.Y, takim[k].Birlik[j].Can);
                                        //Console.ReadKey();
                                        vurdu = true;
                                        break;
                                        
                                    }
                                }
                            }
                            if (!vurdu)
                                Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} --->kordinatlari({3},{4}) ---> {5} Cani var -----> Vurulacak Hedef yok", takim[i].Ad, oyuncuno + 1, takim[i].Birlik[oyuncuno].GetType().Name,
                                takim[i].Birlik[oyuncuno].Koordinat.X, takim[i].Birlik[oyuncuno].Koordinat.Y, takim[i].Birlik[oyuncuno].Can);
                                //Console.ReadKey();
                        }

                        else if (rnd_number >= 0.8) //BEKLE
                        {
                            takim[i].Birlik[oyuncuno].Bekle();
                            Console.WriteLine("{0}.Takim ---> {1}.Birim ---> {2} ---> kordinatlari({3},{4}) ---> {5} Cani var Bekledi", takim[i].Ad, oyuncuno + 1, takim[i].Birlik[oyuncuno].GetType().Name,
                                takim[i].Birlik[oyuncuno].Koordinat.X, takim[i].Birlik[oyuncuno].Koordinat.Y, takim[i].Birlik[oyuncuno].Can);
                            //Console.ReadKey();
                        }
                    }
                }
            }

        }
        // ..... //
    }
}
