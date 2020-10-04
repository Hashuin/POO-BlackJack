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
using BlackJack;
using ClassLibrary1;

namespace WpfApp2
{
    /// <summary>
    /// Lógica de interacción para Game1.xaml
    /// </summary>
    public partial class Game1 : Page
    {

        Player player = new Player();
        Dealer dealer = new Dealer();
        public Game1()
        {
            InitializeComponent();
        }


        private int Check(List<Card> hand)
        {
            int value = 0;

            foreach (Card c in hand)
            {
                if (value + c.Score > 21 && c.Score == 11)
                {
                    value += 1;
                }
                else
                {
                    value += c.Score;
                }
            }
            return value;

        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (player.Hand == null || player.Hand.Count == 0)
            {
                dealer.Generate();
                dealer.Randomize();
                dealer.Init();

                Card c1 = dealer.Deal();
                Card c2 = dealer.Deal();

                player.Init(c1, c2);

                RefreshPlayerCards();


            }
            else
            {
                Card c = dealer.Deal();
                player.AddCard(c);
                RefreshPlayerCards();
            }
            int handValue = Check(player.Hand);
            lblNew.Content = handValue;
            if (handValue > 21)
            {
                btnAdd.IsEnabled = false;
                btnStop.IsEnabled = false;
                MessageBox.Show("La casa gana");
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            txtDealerHand.Text = "";

            foreach (Card c in dealer.Hand)
            {
                txtDealerHand.Text += c.Symbol + c.Suit + "\n";
            }

            while (Check(dealer.Hand) < Check(player.Hand))
            {
                Card c = dealer.Deal();
                dealer.AddCard(c);

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    txtDealerHand.Text += c.Symbol + c.Suit + "\n";
                    DealerScore.Content = Check(dealer.Hand);
                });
            }
            int DealerValue = Check(dealer.Hand);
            DealerScore.Content = DealerValue;
            int handValue = Check(player.Hand);
            lblNew.Content = handValue;
            if (DealerValue > 21)
            {
                btnAdd.IsEnabled = false;
                btnStop.IsEnabled = false;
                MessageBox.Show("El jugador gana");
            }
            if (handValue > DealerValue && handValue <= 21)
            {
                btnAdd.IsEnabled = false;
                btnStop.IsEnabled = false;
                MessageBox.Show("El jugador gana");
            }
            else
            {
                if (handValue == DealerValue)
                {
                    btnAdd.IsEnabled = false;
                    btnStop.IsEnabled = false;
                    MessageBox.Show("Draw");
                }
                else
                {
                    btnAdd.IsEnabled = false;
                    btnStop.IsEnabled = false;
                    MessageBox.Show("La casa gana");
                }
            }
        }

        private string GetText()
        {
            return txtDealerHand.Text;
        }

        private void RefreshPlayerCards()
        {
            txtHand.Text = " ";

            foreach (Card c in player.Hand)
            {
                txtHand.Text += c.Symbol + c.Suit + "\n";
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}    

