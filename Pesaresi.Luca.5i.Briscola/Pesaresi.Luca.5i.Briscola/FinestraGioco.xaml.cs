using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Pesaresi.Luca._5i.Briscola
{
    public partial class FinestraGioco : Window
    {
        BitmapImage vuoto = new BitmapImage();
        BitmapImage retro = new BitmapImage(new Uri(@".\Resources\retro.jpg", UriKind.Relative));
        public FinestraGioco(string NomeGiocatore,bool MostraPunti)
        {
            InitializeComponent();
            lblGiocatore.Content = NomeGiocatore;
            if (MostraPunti == true)
            {
                lblPuntiGiocatore.Opacity = 100;
                lblPuntiPC.Opacity = 100;
                lblGiocatore1.Opacity = 100;
                lblPC1.Opacity = 100;
            }              
        }    
        
        private void Finestra_Gioco_Loaded(object sender, RoutedEventArgs e)
        {
            Avvio();
        }

        private void Avvio()
        {
            Globali.presaGiocatore = 0;
            Globali.presaPC = 0;
            lblPuntiPC.Content = 0;
            lblPuntiGiocatore.Content = 0;
            Globali.contaCarte = 0;
            imgCampo1.Source = vuoto;
            imgCampo2.Source = vuoto;
            imgPC1.Source = retro;
            imgPC2.Source = retro;
            imgPC3.Source = retro;
            imgRetro.Opacity = 100;
            imgBris.Opacity = 100;
            Globali.turnoGiocatore = true;
            CreaMazzo();
            DistribuzionePrimeCarte();

        }
        public void CreaMazzo()
        {
            Mazzo m = new Mazzo();
            carta[] CarteMazzo = new carta[40];

            for (int i = 0; i < CarteMazzo.Length; i++)   //genera carte
            {
                CarteMazzo[i] = m.ComponiMazzo(i);
            }

            List<int> lista = new List<int>(40);
            for (int i = 0; i < CarteMazzo.Length; i++)   //mischia carte
            {
                int carta;
                var random = new Random();
                do carta = random.Next(0, 40);
                while (lista.Contains(carta));
                lista.Add(carta);
                Globali.Mazzo[i] = CarteMazzo[carta];
            }

            #region grafica prime 6 carte distribuite
            Globali.SemeBriscola = Globali.Mazzo[6].seme;
            imgP1.Source = Globali.Mazzo[0].sfondo;
            imgP2.Source = Globali.Mazzo[1].sfondo;
            imgP3.Source = Globali.Mazzo[2].sfondo;

            imgPC1.Source = retro;
            imgPC2.Source = retro;
            imgPC3.Source = retro;

            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.Rotation = Rotation.Rotate90;
            b.UriSource = Globali.Mazzo[6].sfondo.UriSource;
            b.EndInit();
            imgBris.Source = b;
            imgBris.ToolTip = Globali.Mazzo[6].numero + " di " + Globali.Mazzo[6].seme;
            imgRetro.ToolTip = 34;
            #endregion

        }   //Crea un mazzo con valori casuali
        public void DistribuzionePrimeCarte()    //Distribuisce le Prime 6 carte
        {
            carta[] briscola = new carta[1];

            for (int i = 0, c = 0; i < 40; i++, c++) //slitta carte nel mazzo
            {
                if (c < 3)
                {
                    Globali.CarteGiocatore[i] = Globali.Mazzo[c];
                    Globali.Mazzo[c] = null;
                }

                else if (c < 6)
                {
                    Globali.CartePC[i - 3] = Globali.Mazzo[c];
                    Globali.Mazzo[c] = null;
                }
                else if (c == 6)
                {

                    briscola[0] = Globali.Mazzo[c];
                    Globali.Mazzo[c] = null;
                }
                else if (c > 6)
                {
                    Globali.Mazzo[i - 7] = Globali.Mazzo[i];
                    Globali.Mazzo[i] = null;
                }

            }
            Globali.Mazzo[33] = briscola[0];

        }
        private void DistribuzioneCarte(int Giocatore, int Carta)
        {
            if (Globali.contaCarte < 34) //se ci sono ancora carte nel mazzo
            {
                if (Globali.contaCarte == 32)
                    imgRetro.Opacity = 0;
                else if (Globali.contaCarte == 33)
                    imgBris.Opacity = 0;


                if (Giocatore == 0) //da le carta mancante al giocatore
                {
                    Globali.CarteGiocatore[Carta] = Globali.Mazzo[Globali.contaCarte];
                    if (Carta == 0)
                    {
                        imgP1.Source = Globali.CarteGiocatore[Carta].sfondo;
                        imgP1.Opacity = 100;
                    }
                    else if (Carta == 1)
                    {
                        imgP2.Source = Globali.CarteGiocatore[Carta].sfondo;
                        imgP2.Opacity = 100;
                    }
                    else if (Carta == 2)
                    {
                        imgP3.Source = Globali.CarteGiocatore[Carta].sfondo;
                        imgP3.Opacity = 100;
                    }
                }
                else //da le carta mancante al pc 
                {
                    Globali.CartePC[Carta] = Globali.Mazzo[Globali.contaCarte];

                    if (Carta == 0)
                    {
                        imgPC1.Source = retro;
                        imgPC1.Opacity = 100;
                    }
                    else if (Carta == 1)
                    {
                        imgPC2.Source = retro;
                        imgPC2.Opacity = 100;
                    }
                    else if (Carta == 2)
                    {
                        imgPC3.Source = retro;
                        imgPC3.Opacity = 100;
                    }
                }

                Globali.Mazzo[Globali.contaCarte] = null;
                Globali.contaCarte++;
            }
        } //Distribuisce la Carta Mancante
        private void imgP1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgP1.Source = vuoto;
            imgP123(0);
        }
        private void imgP2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgP2.Source = vuoto;
            imgP123(1);
        }
        private void imgP3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            imgP3.Source = vuoto;
            imgP123(2);
        }
        private async void imgP123(int n)
        {
            imgP1.IsEnabled = false;
            imgP2.IsEnabled = false;
            imgP3.IsEnabled = false;
            Globali.cartaGiocatore = n;
            if (Globali.turnoGiocatore == true) //tira il giocatore per primo
            {
                Globali.CarteCampo[0] = Globali.CarteGiocatore[n];
                Globali.CarteCampo[1] = Bot();
                Globali.CartePC[Globali.cartaPC] = null;
                Presa(Globali.CarteCampo[0], Globali.CarteCampo[1]);
                if (Globali.presa[1] == 23)
                {
                    Globali.presaGiocatore += Globali.presa[0];
                    Globali.turnoGiocatore = true;
                }

                else if (Globali.presa[0] == 23)
                {
                    Globali.presaPC += Globali.presa[1];
                    Globali.turnoGiocatore = false;
                }

                //grafica
                imgCampo1.Source = Globali.CarteGiocatore[n].sfondo;
                await Attesa(500);
                imgCampo2.Source = Globali.CarteCampo[1].sfondo;
            }
            else //il giocatore tira per secondo
            {
                Globali.CarteCampo[1] = Globali.CarteGiocatore[n];
                Presa(Globali.CarteCampo[0], Globali.CarteCampo[1]);
                if (Globali.presa[1] == 23)
                {
                    Globali.presaPC += Globali.presa[0];
                    Globali.turnoGiocatore = false;
                }

                else if (Globali.presa[0] == 23)
                {
                    Globali.presaGiocatore += Globali.presa[1];
                    Globali.turnoGiocatore = true;
                }

                //grafica
                imgCampo2.Source = Globali.CarteCampo[1].sfondo;
            }
            await Attesa(1500);
            DaiCarta();
        }
        async Task Attesa(int ms) //millisecondi
        {
            await Task.Delay(ms);
        }
        private void EliminaCartePC()
        {
            switch (Globali.cartaPC)
            {
                case 0:
                    imgPC1.Source = vuoto;
                    break;
                case 1:
                    imgPC2.Source = vuoto;
                    break;
                case 2:
                    imgPC3.Source = vuoto;
                    break;
            }
        }
        private void FinePartita()
        {
            imgCampo1.Source = vuoto;
            imgCampo2.Source = vuoto;
            lblPuntiGiocatore.Content = Globali.presaGiocatore;
            lblPuntiPC.Content = Globali.presaPC;

            if (Globali.presaGiocatore + Globali.presaPC < 120)
                if (Globali.presaGiocatore > Globali.presaPC)
                {
                    int a = 120 - Globali.presaPC;
                    Globali.presaGiocatore = a;
                }
                else
                {
                    int a = 120 - Globali.presaGiocatore;
                    Globali.presaPC = a;
                }   
                    
            if (Globali.presaGiocatore > 60)
                MessageBox.Show("Hai vinto!! \nIl tuo punteggio è di " + Globali.presaGiocatore + " punti e il PC " + Globali.presaPC + " punti", "Parita Terminata", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (Globali.presaGiocatore < 60)
                MessageBox.Show("Hai perso!! \nIl PC ha vinto con " + Globali.presaPC + " punti e tu solamente " + Globali.presaGiocatore, "Parita Terminata", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Wow! Pareggio!! \nEntrambi avete totalizzato " + Globali.presaGiocatore + " punti", "Parita Terminata", MessageBoxButton.OK, MessageBoxImage.Information);

            if (MessageBox.Show("Cominciare una nuova partita?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Avvio();
            }
            else
            {
                this.Close();       
            }                                           
        }
        carta Bot()
        {
            carta[] c = new carta[1];
            int lenght = Globali.CartePC.Length;
            int flag = 0;

            //Carte Finite
            if (Globali.CartePC[0] == null && Globali.CartePC[1] == null && Globali.CartePC[2] == null)
                FinePartita();

            //Solo 1 carta rimasta
            if (Globali.CartePC[0] == null || Globali.CartePC[1] == null || Globali.CartePC[2] == null)
            {
                for (int i = 0, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        indice = i;
                        flag = 1;
                        Globali.cartaPC = i;
                    }
                    if (i >= 2 && flag == 1)
                    {
                        Globali.cartaPC = indice;
                        EliminaCartePC();
                        return c[0] = Globali.CartePC[indice];
                    }
                }
            }
            //Il bot tira per primo
            if (Globali.turnoGiocatore == false)
            {
                //eccezione: se il pc ha solo carichi e  briscole e deve tirare la briscola più bassa
                c[0] = Eccezione();
                if (c[0] != null)
                    return c[0];

                //tirare liscio
                c[0] = Liscio();
                if (c[0] != null)
                    return c[0];

                // se il pc ha solo briscola
                c[0] = SoloBriscola();
                if (c[0] != null)
                    return c[0];
            }

            //il bot deve tira per secondo
            else if (Globali.turnoGiocatore == true)
            {
                //se è una briscola
                if (Globali.CarteCampo[0].seme == Globali.SemeBriscola)
                {
                    //eccezione: il giocatore tira Tre di briscola --> il pc se lo ha tira Asso di briscola
                    for (int i = 0; i < lenght; i++)
                    {
                        if (Globali.CartePC[i] != null)
                        {
                            if (Globali.CartePC[i].seme == Globali.SemeBriscola && Globali.CartePC[i].valore > 10 && Globali.CarteCampo[0].valore == 10)
                            {
                                EliminaCartePC();
                                Globali.cartaPC = i;
                                return c[0] = Globali.CartePC[i];
                            }
                        }
                    }

                    //eccezione: se il pc ha 2 carichi e 1 briscola e deve per forza prendere con la briscola 
                    c[0] = Eccezione();
                    if (c[0] != null)
                        return c[0];

                    //tirare liscio
                    c[0] = Liscio();
                    if (c[0] != null)
                        return c[0];

                    // se il pc ha solo briscola
                    c[0] = SoloBriscola();
                    if (c[0] != null)
                        return c[0];
                }

                //se non è brisccola
                else
                {
                    //se il pc può superare la carta
                    flag = 0;
                    for (int i = 0, valore = Globali.CarteCampo[0].valore, indice = 0; i < lenght; i++)
                    {
                        if (Globali.CartePC[i] != null)
                        {
                            if (Globali.CartePC[i].seme == Globali.CarteCampo[0].seme && Globali.CartePC[i].valore > valore)
                            {
                                valore = Globali.CartePC[i].valore;
                                indice = i;
                                flag = 1;
                            }
                            if (i >= 2 && flag == 1)
                            {
                                Globali.cartaPC = indice;
                                EliminaCartePC();
                                return c[0] = Globali.CartePC[indice];
                            }
                        }
                    }

                    //eccezione: se il giocatore tira un carico il pc prende se ha una briscola
                    if (Globali.CarteCampo[0].valore >= 10)
                    {
                        for (int i = 0, valore = 11, indice = 0; i < lenght; i++)
                        {
                            if (Globali.CartePC[i] != null)
                            {
                                if (Globali.CartePC[i].seme == Globali.SemeBriscola && Globali.CartePC[i].valore < valore)
                                {
                                    valore = Globali.CartePC[i].valore;
                                    indice = i;
                                    flag = 1;
                                }
                                if (i >= 2 && flag == 1)
                                {
                                    Globali.cartaPC = indice;
                                    EliminaCartePC();
                                    return c[0] = Globali.CartePC[indice];
                                }
                            }
                        }
                    }

                    //eccezione: se il pc ha 2 carichi e 1 briscola e deve per forza prendere con la briscola 
                    c[0] = Eccezione();
                    if (c[0] != null)
                        return c[0];

                    //tirare liscio
                    c[0] = Liscio();
                    if (c[0] != null)
                        return c[0];

                    // se il pc ha solo briscola
                    c[0] = SoloBriscola();
                    if (c[0] != null)
                        return c[0];
                }
            }

            return c[0];
        }       //Intelligenza artificiale
        private carta Liscio()
        {
            int flag = 0;
            carta[] c = new carta[1];
            int lenght = Globali.CartePC.Length;

            if (Globali.turnoGiocatore == true)
            {
                //tirare liscio
                for (int i = 0, numero = Globali.CarteCampo[0].numero; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        //liscio
                        if (Globali.CartePC[i].valore == 0 && Globali.CartePC[i].seme != Globali.SemeBriscola)
                        {
                            if ((Globali.CartePC[i].seme != Globali.CarteCampo[0].seme) || (Globali.CartePC[i].seme == Globali.CarteCampo[0].seme && Globali.CartePC[i].numero < numero))
                            {
                                Globali.cartaPC = i;
                                EliminaCartePC();
                                return c[0] = Globali.CartePC[i];
                            }
                        }
                    }
                }
                //se il pc non ha liscio tira punto più basso     
                flag = 0;
                for (int i = 0, valore = 11, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore < valore && Globali.CartePC[i].seme != Globali.SemeBriscola)
                        {
                            valore = Globali.CartePC[i].valore;
                            indice = i;
                            flag = 1;
                        }
                        if (i >= 2 && flag == 1)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }
            else //se il pc tira per primo
            {
                //liscio
                for (int i = 0, numero = 10, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        //tira il liscio più basso
                        if (Globali.CartePC[i].valore == 0 && Globali.CartePC[i].seme != Globali.SemeBriscola)
                        {
                            if (Globali.CartePC[i].numero < numero)
                            {
                                numero = Globali.CartePC[i].numero;
                                indice = i;
                                flag = 1;
                            }
                            if (i >= 2 && flag == 1)
                            {
                                Globali.cartaPC = indice;
                                EliminaCartePC();
                                return c[0] = Globali.CartePC[indice];
                            }
                        }
                    }


                }

                //se il pc non ha liscio tira punto più basso  
                flag = 0;
                for (int i = 0, valore = 11, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore < valore && Globali.CartePC[i].seme != Globali.SemeBriscola)
                        {
                            valore = Globali.CartePC[i].valore;
                            indice = i;
                            flag = 1;
                        }
                        if (i >= 2 && flag == 1)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }
            return c[0];
        } //Ricerca della carta con valore più basso
        private carta Eccezione()
        {
            carta[] c = new carta[1];
            int lenght = Globali.CartePC.Length;

            if (Globali.turnoGiocatore == false)
            {
                for (int i = 0, indice = 0, cont = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore > 4 && Globali.CartePC[i].seme != Globali.SemeBriscola)
                            cont++;
                        else
                            indice = i;
                        if (i >= 2 && cont == 2)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0, indice = 0, cont = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore > 4 && Globali.CarteCampo[0].valore >= 2 && Globali.CartePC[i].seme != Globali.SemeBriscola)
                            cont++;
                        else
                            indice = i;
                        if (i >= 2 && cont == 2)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }
            return c[0];
        }  
        private carta SoloBriscola()
        {
            carta[] c = new carta[1];
            int lenght = Globali.CartePC.Length;
            int flag = 0;
            if (Globali.turnoGiocatore == false)
            {
                for (int i = 0, valore = 11, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore <= valore && Globali.CartePC[i].seme == Globali.SemeBriscola)
                        {
                            valore = Globali.CartePC[i].valore;
                            indice = i;
                            flag = 1;
                        }
                        if (i >= 2 && flag == 1)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0, valore = 11, indice = 0; i < lenght; i++)
                {
                    if (Globali.CartePC[i] != null)
                    {
                        if (Globali.CartePC[i].valore <= valore && Globali.CartePC[i].seme == Globali.SemeBriscola)
                        {
                            valore = Globali.CartePC[i].valore;
                            indice = i;
                            flag = 1;
                        }
                        if (i >= 2 && flag == 1)
                        {
                            Globali.cartaPC = indice;
                            EliminaCartePC();
                            return c[0] = Globali.CartePC[indice];
                        }
                    }
                }
            }

            return c[0];
        }    //se il pc ha tutte briscole deve scegliere quella più bassa
        private int[] Presa(carta PrimaCarta, carta SecondaCarta)
        {
            //se sono due briscole
            if (PrimaCarta.seme == Globali.SemeBriscola && SecondaCarta.seme == Globali.SemeBriscola)
            {
                if (PrimaCarta.valore > SecondaCarta.valore)
                {
                    Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                    Globali.presa[1] = 23;
                }

                else if (PrimaCarta.valore < SecondaCarta.valore)
                {
                    Globali.presa[1] = PrimaCarta.valore + SecondaCarta.valore;
                    Globali.presa[0] = 23;
                }

                else //valore uguale
                {
                    if (PrimaCarta.numero > SecondaCarta.numero)
                    {
                        Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                        Globali.presa[1] = 23;
                    }
                    else
                    {
                        Globali.presa[1] = PrimaCarta.valore + SecondaCarta.valore;
                        Globali.presa[0] = 23;
                    }
                }
            }
            //se solo la prima è briscola
            else if (PrimaCarta.seme == Globali.SemeBriscola && SecondaCarta.seme != Globali.SemeBriscola)
            {
                Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                Globali.presa[1] = 23;
            }
            //se solo la seconda è briscola
            else if (PrimaCarta.seme != Globali.SemeBriscola && SecondaCarta.seme == Globali.SemeBriscola)
            {
                Globali.presa[1] = PrimaCarta.valore + SecondaCarta.valore;
                Globali.presa[0] = 23;
            }
            //se nessuna è briscola
            else
            {
                //seme diverso
                if (PrimaCarta.seme != SecondaCarta.seme)
                {
                    Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                    Globali.presa[1] = 23;
                }
                //stesso seme
                else
                {
                    if (PrimaCarta.valore > SecondaCarta.valore)
                    {
                        Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                        Globali.presa[1] = 23;
                    }
                    else if (PrimaCarta.valore < SecondaCarta.valore)
                    {
                        Globali.presa[1] = PrimaCarta.valore + SecondaCarta.valore;
                        Globali.presa[0] = 23;
                    }
                    else //valore uguale
                    {
                        if (PrimaCarta.numero > SecondaCarta.numero)
                        {
                            Globali.presa[0] = PrimaCarta.valore + SecondaCarta.valore;
                            Globali.presa[1] = 23;
                        }
                        else
                        {
                            Globali.presa[1] = PrimaCarta.valore + SecondaCarta.valore;
                            Globali.presa[0] = 23;
                        }
                    }
                }
            }
            return Globali.presa;

        } //Decide a chi dare il punto della mano giocata
        private async void DaiCarta()
        {
            if (Globali.CartePC[0] == null && Globali.CartePC[1] == null && Globali.CartePC[2] == null)
            {
                FinePartita();
            }
            imgCampo1.Source = vuoto;
            imgCampo2.Source = vuoto;

            if (Globali.turnoGiocatore == true)// da le carta mancante
            {
                DistribuzioneCarte(0, Globali.cartaGiocatore); //prima al giocatore
                DistribuzioneCarte(1, Globali.cartaPC);        //poi al PC
            }
            else
            {
                DistribuzioneCarte(1, Globali.cartaPC);         //prima al PC
                DistribuzioneCarte(0, Globali.cartaGiocatore);  //poi al giocatore
                Globali.CarteCampo[0] = Bot();                
                Globali.CartePC[Globali.cartaPC] = null;
                await Attesa(500);
                imgCampo1.Source = Globali.CarteCampo[0].sfondo;
            }

            //aggiorna grafica
            lblPuntiGiocatore.Content = Globali.presaGiocatore;
            lblPuntiPC.Content = Globali.presaPC;
            imgP1.IsEnabled = true;
            imgP2.IsEnabled = true;
            imgP3.IsEnabled = true;
            imgRetro.ToolTip = 34 - Globali.contaCarte;
        }   //Da la carta ai giocatori e stabilisce chi inizia
        private void Finestra_Gioco_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool uscire = Esci();
            if (uscire == true)
                 e.Cancel = uscire;        
        }
        private bool Esci()
        {
            //Chiude con Avviso e Ritorna al Menù
            if (MessageBox.Show("Se sicuro di volere uscire?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string s = Convert.ToString(lblGiocatore.Content);
                FinestraGioco fs = new FinestraGioco(s, false);
                fs.Hide();             
                MainWindow main = new MainWindow();
                main.Rigioca();                              
                return false;
            }
            else
                return true;
        }
        private void Rigioca_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di volere iniziare una nuova partita?", "Attenzione", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Avvio();
        }
        private void Esci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Questo programma è stato programmato e sviluppato interamente da Luca Pesaresi.\nPuoi trovare maggiori informazioni sul blog https://lucapesaresi.blogspot.it/", "Informazioni", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}