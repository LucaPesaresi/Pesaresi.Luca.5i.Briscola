using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pesaresi.Luca._5i.Briscola
{
    class Mazzo
    {
        //bastoni  (numero,valore,seme,posizione)
        carta uno_bastoni = new carta(1, 11, "bastoni", (new Uri(@".\Resources\1.jpg", UriKind.Relative)));
        carta due_bastoni = new carta(2, 0, "bastoni", (new Uri(@".\Resources\2.jpg", UriKind.Relative)));
        carta tre_bastoni = new carta(3, 10, "bastoni", (new Uri(@".\Resources\3.jpg", UriKind.Relative)));
        carta quattro_bastoni = new carta(4, 0, "bastoni", (new Uri(@".\Resources\4.jpg", UriKind.Relative)));
        carta cinque_bastoni = new carta(5, 0, "bastoni", (new Uri(@".\Resources\5.jpg", UriKind.Relative)));
        carta sei_bastoni = new carta(6, 0, "bastoni", (new Uri(@".\Resources\6.jpg", UriKind.Relative)));
        carta sette_bastoni = new carta(7, 0, "bastoni", (new Uri(@".\Resources\7.jpg", UriKind.Relative)));
        carta otto_bastoni = new carta(8, 2, "bastoni", (new Uri(@".\Resources\8.jpg", UriKind.Relative)));
        carta nove_bastoni = new carta(9, 3, "bastoni", (new Uri(@".\Resources\9.jpg", UriKind.Relative)));
        carta dieci_bastoni = new carta(10, 4, "bastoni", (new Uri(@".\Resources\10.jpg", UriKind.Relative)));

        //coppe
        carta uno_coppe = new carta(1, 11, "coppe", (new Uri(@".\Resources\11.jpg", UriKind.Relative)));
        carta due_coppe = new carta(2, 0, "coppe", (new Uri(@".\Resources\12.jpg", UriKind.Relative)));
        carta tre_coppe = new carta(3, 10, "coppe", (new Uri(@".\Resources\13.jpg", UriKind.Relative)));
        carta quattro_coppe = new carta(4, 0, "coppe", (new Uri(@".\Resources\14.jpg", UriKind.Relative)));
        carta cinque_coppe = new carta(5, 0, "coppe", (new Uri(@".\Resources\15.jpg", UriKind.Relative)));
        carta sei_coppe = new carta(6, 0, "coppe", (new Uri(@".\Resources\16.jpg", UriKind.Relative)));
        carta sette_coppe = new carta(7, 0, "coppe", (new Uri(@".\Resources\17.jpg", UriKind.Relative)));
        carta otto_coppe = new carta(8, 2, "coppe", (new Uri(@".\Resources\18.jpg", UriKind.Relative)));
        carta nove_coppe = new carta(9, 3, "coppe", (new Uri(@".\Resources\19.jpg", UriKind.Relative)));
        carta dieci_coppe = new carta(10, 4, "coppe", (new Uri(@".\Resources\20.jpg", UriKind.Relative)));

        //denari
        carta uno_denari = new carta(1, 11, "denari", (new Uri(@".\Resources\21.jpg", UriKind.Relative)));
        carta due_denari = new carta(2, 0, "denari", (new Uri(@".\Resources\22.jpg", UriKind.Relative)));
        carta tre_denari = new carta(3, 10, "denari", (new Uri(@".\Resources\23.jpg", UriKind.Relative)));
        carta quattro_denari = new carta(4, 0, "denari", (new Uri(@".\Resources\24.jpg", UriKind.Relative)));
        carta cinque_denari = new carta(5, 0, "denari", (new Uri(@".\Resources\25.jpg", UriKind.Relative)));
        carta sei_denari = new carta(6, 0, "denari", (new Uri(@".\Resources\26.jpg", UriKind.Relative)));
        carta sette_denari = new carta(7, 0, "denari", (new Uri(@".\Resources\27.jpg", UriKind.Relative)));
        carta otto_denari = new carta(8, 2, "denari", (new Uri(@".\Resources\28.jpg", UriKind.Relative)));
        carta nove_denari = new carta(9, 3, "denari", (new Uri(@".\Resources\29.jpg", UriKind.Relative)));
        carta dieci_denari = new carta(10, 4, "denari", (new Uri(@".\Resources\30.jpg", UriKind.Relative)));

        //spade
        carta uno_spade = new carta(1, 11, "spade", (new Uri(@".\Resources\31.jpg", UriKind.Relative)));
        carta due_spade = new carta(2, 0, "spade", (new Uri(@".\Resources\32.jpg", UriKind.Relative)));
        carta tre_spade = new carta(3, 10, "spade", (new Uri(@".\Resources\33.jpg", UriKind.Relative)));
        carta quattro_spade = new carta(4, 0, "spade", (new Uri(@".\Resources\34.jpg", UriKind.Relative)));
        carta cinque_spade = new carta(5, 0, "spade", (new Uri(@".\Resources\35.jpg", UriKind.Relative)));
        carta sei_spade = new carta(6, 0, "spade", (new Uri(@".\Resources\36.jpg", UriKind.Relative)));
        carta sette_spade = new carta(7, 0, "spade", (new Uri(@".\Resources\37.jpg", UriKind.Relative)));
        carta otto_spade = new carta(8, 2, "spade", (new Uri(@".\Resources\38.jpg", UriKind.Relative)));
        carta nove_spade = new carta(9, 3, "spade", (new Uri(@".\Resources\39.jpg", UriKind.Relative)));
        carta dieci_spade = new carta(10, 4, "spade", (new Uri(@".\Resources\40.jpg", UriKind.Relative)));

        public carta ComponiMazzo(int n) //ritorna la carta precisa
        {
           
            switch (n)
            {
                case 0: return uno_bastoni; 
                case 1: return due_bastoni; 
                case 2: return tre_bastoni; 
                case 3: return quattro_bastoni; 
                case 4: return cinque_bastoni; 
                case 5: return sei_bastoni; 
                case 6: return sette_bastoni; 
                case 7: return otto_bastoni; 
                case 8: return nove_bastoni; 
                case 9: return dieci_bastoni;
                case 10: return uno_coppe;
                case 11: return due_coppe;
                case 12: return tre_coppe;
                case 13: return quattro_coppe;
                case 14: return cinque_coppe;
                case 15: return sei_coppe;
                case 16: return sette_coppe;
                case 17: return otto_coppe;
                case 18: return nove_coppe;
                case 19: return dieci_coppe;
                case 20: return uno_denari;
                case 21: return due_denari; 
                case 22: return tre_denari;
                case 23: return quattro_denari;
                case 24: return cinque_denari;
                case 25: return sei_denari;
                case 26: return sette_denari;
                case 27: return otto_denari;
                case 28: return nove_denari;
                case 29: return dieci_denari;
                case 30: return uno_spade;
                case 31: return due_spade;
                case 32: return tre_spade;
                case 33: return quattro_spade;
                case 34: return cinque_spade;
                case 35: return sei_spade;
                case 36: return sette_spade;
                case 37: return otto_spade;
                case 38: return nove_spade;
                case 39: return dieci_spade;

                default:
                    {
                        return null;
                    }
            }
        }
    }
}