using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Pesaresi.Luca._5i.Briscola
{
    public class carta
    {
        public int numero { get; set; }
        public int valore { get; set; }
        public string seme { get; set; }
        public BitmapImage sfondo { get; set; }

        public carta(int n, int v, string s, Uri posizione)
        {
            numero = n;
            valore = v;
            seme = s;
            sfondo = new BitmapImage(posizione);
        }        

    }
}
