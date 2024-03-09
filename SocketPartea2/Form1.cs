using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketPartea2
{
    public partial class ServerClient : Form
    {
        private Deck myDeck;
        private List<Card> drawnCards = new List<Card>();
        public ServerClient()
        {
            InitializeComponent();
            myDeck = new Deck();
            myDeck.Shuffle();
            hitButton.Enabled = false;
            buttonStand.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
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

        //Calculam si initializam valoarea cartilor
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

        //functia care ne mai extrage o carte

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

        int TotalValue;

        enum Responses
        {
            ClientWon,
            ServerWon,
            NobodyWon,
            Draw,
        }

        //aici in butonul stand avem functia care ne determina catigatorul dintre server si client si ne returneaza 
        //0 daca clientul castiga
        //1 daca serverrul cartiga
        //2 daca nu castiga nimeni
        //si 3 daca este egal
        private void buttonStand_Click(object sender, EventArgs e)
        {
            hitButton.Enabled = false;
            int ServerTotalValue = CalculateTotalValue(drawnCards);
            if (TotalValue == 21)
            {
                SendMessage((int)Responses.ClientWon);
            }
            else if (ServerTotalValue == 21)
            {
                SendMessage((int)Responses.ServerWon);
            }
            else if (TotalValue > 21 && ServerTotalValue > 21)
            {
                SendMessage((int)Responses.NobodyWon);
            }
            else if (TotalValue > 21 && ServerTotalValue < 21)
            {
                SendMessage((int)Responses.ServerWon);
            }
            else if (TotalValue < 21 && ServerTotalValue > 21)
            {
                SendMessage((int)Responses.ClientWon);
            }
            else
            {
                if(TotalValue > ServerTotalValue)
                {
                    SendMessage((int)Responses.ClientWon);
                }
                else if(TotalValue == ServerTotalValue)
                {
                    SendMessage((int)Responses.Draw);
                }
                else
                {
                    SendMessage((int)Responses.ServerWon);
                }

            }
            
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

        private TcpListener server;
        private Thread listenerThread;


        private void StartServerButton_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            listenerThread = new Thread(new ThreadStart(ListenForClients));
            listenerThread.Start();
            LogMessage("Server started. Waiting for connections...");
        }

        private void ListenForClients()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();

            while (true)
            {
                TotalValue = 0;
                if (sendMessage)
                {
                    clientStream.WriteByte((byte)sendData);
                    sendMessage= false;
                    sendData = 0;
                }
                try
                {
                    TotalValue = clientStream.ReadByte();
                }
                catch
                {
                    break;
                }



                if (TotalValue == 0)
                    continue;
            }

            tcpClient.Close();
        }

       
        bool sendMessage;
        int sendData;
        private void SendMessage(int data)
        {
            sendMessage = true ;
            sendData = data;
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }

            serverLogTextBox.AppendText($"{message}\n");
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Stop();
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

        private void StartServerButton_Click_1(object sender, EventArgs e)
        {
            StartServerButton_Click(sender, e);
        }

    }
}
