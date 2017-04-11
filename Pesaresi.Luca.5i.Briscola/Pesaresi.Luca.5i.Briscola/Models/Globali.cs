using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Pesaresi.Luca._5i.Briscola
{
    public static class Globali
    {
        public static carta[] Mazzo = new carta[40];               //40 carte nel mazzo
        public static carta[] CarteGiocatore = new carta[3];       //3 carte al giocatore
        public static carta[] CartePC = new carta[3];              //3 carte al Computer
        public static carta[] CarteCampo = new carta[2];           //2 carte in campo
        public static int[] presa = new int[2];                    //0:presa della prima carta, 1:presa della seconda carta
        public static int presaPC{ get; set; }                     //Punti PC
        public static int presaGiocatore{ get; set; }              //Punti Giocatore
        public static int contaCarte = 0;               
        public static string SemeBriscola = "";
        public static bool turnoGiocatore = true;
        public static int cartaPC{ get; set; }                     //indice carta PC   
        public static int cartaGiocatore{ get; set; }              //indice carta Giocatore
        

    }
}
