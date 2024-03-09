using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPartea2
{
    public partial class ClientForm : Form
    {
        private Deck myDeck;
        private List<Card> drawnCards = new List<Card>();
        public ClientForm()
        {
            InitializeComponent();
            myDeck = new Deck();
            myDeck.Shuffle();
            hitButton.Enabled = false;
            buttonStand.Enabled = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            //Extragem 2 carti din pachetul de joc
            List<Card> currentlyDrawnCards = DrawCards(myDeck.getCards().Count);
            drawnCards.AddRange(currentlyDrawnCards);

            DisplayDrawnCards(drawnCards);

            //Calculam si afisam intr-un label valoarea cartilor extrase
            int totalValue = CalculateTotalValue(drawnCards);
            totalValueLabel.Text = $"Total Value : {totalValue}";
            DrawButton.Enabled = false;
            hitButton.Enabled = true;
            buttonStand.Enabled = true;

            if (totalValue > 21)
            {
                MessageBox.Show("You Lost", "Game Over");
            }
            else if (totalValue == 21)
            {
                MessageBox.Show("Congrats!", "You Win");
            }

        }

        private List<Card> DrawCards(int numberOfCardsInDeck)
        {
            Random rand = new Random();
            if (numberOfCardsInDeck == 0)
            {
                MessageBox.Show("No more cards in the deck!", "Deck is Empty!");
                return new List<Card>();

            }
            else
            {
                List<Card> currentlyDrawnCards = new List<Card>(2);
                if (numberOfCardsInDeck == 1)
                {
                    currentlyDrawnCards.Add(myDeck.getCard(0));
                    return currentlyDrawnCards;
                }

                int firstRandomCardIndex = rand.Next(0, numberOfCardsInDeck);
                int secondRandomCardIndex = rand.Next(0, numberOfCardsInDeck);
                while (firstRandomCardIndex == secondRandomCardIndex)
                {
                    secondRandomCardIndex = rand.Next(0, numberOfCardsInDeck);
                }
               

                currentlyDrawnCards.Add(myDeck.getCard(firstRandomCardIndex));
                currentlyDrawnCards.Add(myDeck.getCard(secondRandomCardIndex));

                // Daca primul indice generat este mai mic decat cel de al doilea,
                // si il stergem pe acesta primul, din vector, atunci al doilea indice generat
                // nu va mai arata catre cardul initial
                // exemplu:
                // [1, 2, 3, 4], first: 0, second: 1
                // stergem prima oara elementul de pe pozitia 0 -> [2, 3, 4]
                // second in mod normal s-ar fi referit la elementul 2, dar acum se refera la elementul 3
                // de aceea va trebui sa stergem indicele de pe pozitia mai mare.

                if (firstRandomCardIndex < secondRandomCardIndex)
                {
                    int aux = firstRandomCardIndex;
                    firstRandomCardIndex = secondRandomCardIndex;
                    secondRandomCardIndex = aux;
                }

                myDeck.removeCard(myDeck.getCard(firstRandomCardIndex));
                myDeck.removeCard(myDeck.getCard(secondRandomCardIndex));

                return currentlyDrawnCards;
            }
        }
        private void DisplayDrawnCards(List<Card> drawnCards)
        {
            //Cartile le afisam intr-un label
            DrawCardsLabel.Text = "Drawn Cards:\n";

            foreach (Card card in drawnCards)
            {
                DrawCardsLabel.Text += card.DisplayCard() + "\n";
            }
        }

        private int CalculateTotalValue(List<Card> drawnCards)
        {
            int totalValue = 0;

            foreach (Card card in drawnCards)
            {
                switch (card.Rank)
                {
                    case "Ace":
                        totalValue += 11;
                        break;
                    case "Jack":
                        totalValue += 12;
                        break;
                    case "Queen":
                        totalValue += 13;
                        break;
                    case "King":
                        totalValue += 14;
                        break;
                    default:
                        // int.Parse transforma un sir de caractere numeric ("1", "2", "20", etc) in int
                        int cardRank = int.Parse(card.Rank);
                        totalValue += cardRank;
                        break;
                }
            }
            return totalValue;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            Card randomCard = HitCard();
            if (randomCard != null)
            {
                DrawCardsLabel.Text += $"Hit Card : {randomCard.DisplayCard()} \n";

                int totalValue = CalculateTotalValue(drawnCards);
                totalValueLabel.Text = $"Total Value : {totalValue}";

                if (totalValue > 21)
                {
                    MessageBox.Show("You Lost", "Game Over");
                }
                else if (totalValue == 21)
                {
                    MessageBox.Show("Congrats!", "You Win");
                }
                else if (totalValue < 21)
                {
                    hitButton.Enabled = true;
                }
            }
        }

        private Card HitCard()
        {
            if (myDeck.getCards().Count == 0)
            {
                MessageBox.Show("There are no more cards left.");
                return null;
            }
            else
            {
                Random rand = new Random();
                int randomIndex = rand.Next(0, myDeck.getCards().Count);

                Card hitCard = myDeck.getCard(randomIndex);
                myDeck.removeCard(hitCard);

                drawnCards.Add(hitCard);
                return hitCard;
            }
        }

        enum Responses
        {
            ClientWon,
            ServerWon,
            NobodyWon,
            Draw,
        }

        private void buttonStand_Click(object sender, EventArgs e)
        {
            hitButton.Enabled = false;
            int ValoareTotala = CalculateTotalValue(drawnCards);
            clientStream.WriteByte((byte)ValoareTotala);

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DrawButton.Enabled = true;
            hitButton.Enabled = false;
            buttonStand.Enabled = false;
            drawnCards.Clear();
            DisplayDrawnCards(drawnCards);
            myDeck.InitializeDeck();
            totalValueLabel.Text = $"Total Value : 0";

        }


        private TcpClient client;
        private Thread clientThread;
        private NetworkStream clientStream;


        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            client = new TcpClient();
            client.Connect("127.0.0.1", 8888);

            clientStream = client.GetStream();
            LogMessage("Connected to server");

            

            // Creem un nou Thread pentru a asculta mesajele de la server
            clientThread = new Thread(new ThreadStart(ListenForServerMessages));
            clientThread.Start();
        }

        int decision;

        //informatile primite de la server
        private void ListenForServerMessages()
        {
            try
            {
                while (true)
                {
                    
                    // Citeste mesajele primite
                    int bytesSent = clientStream.ReadByte();
                    if (bytesSent == -1)
                    {
                        continue;
                    }
                    //Clientul primeste de la server decizia
                    decision = bytesSent;
                    if((Responses)decision == Responses.Draw)
                    {
                        LogMessage("Draw");
                    }
                    else if((Responses)decision == Responses.ClientWon){
                        LogMessage("ClientWon");
                    }
                    else if((Responses)decision == Responses.NobodyWon)
                    {
                        LogMessage("NobodyWon");
                    }
                    else if((Responses)decision == Responses.ServerWon)
                    {
                        LogMessage("ServerWon");
                    }

                }
            }
            catch (Exception ex)
            {
                // Se intampla atata timp cat conexiunea nu se inchide
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        //mesajul primit de la server
        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            clientLogTextBox.AppendText($"{message}\n");
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                client.Close();
            }
        }

        private void DrawButton_Click_1(object sender, EventArgs e)
        {
            DrawButton_Click(sender, e);
        }

        private void hitButton_Click_1(object sender, EventArgs e)
        {
            hitButton_Click(sender, e);
        }

        private void buttonStand_Click_1(object sender, EventArgs e)
        {
            buttonStand_Click(sender, e);
        }
        private void buttonReset_Click_1(object sender, EventArgs e)
        {
            buttonReset_Click(sender, e);
        }

        private void ConnectButton_Click_1(object sender, EventArgs e)
        {
            ConnectButton_Click(sender, e);
        }




    }
}
