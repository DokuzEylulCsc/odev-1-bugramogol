using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        // Burasi bir hücre . Hücre Boşmu dolumu kontrol edilcek  //
        private bool bos;
        private int x, y;
        
        public Bolge()  //Boş olarak gelicekler
        {
            bos = true;
        }

        public bool Bos
        {
            get
            {
                return bos;
            }
            set
            {
                bos = value;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
