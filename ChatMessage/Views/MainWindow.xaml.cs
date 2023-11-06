// Den er ansvarlig for brugergrænsefladen og datahåndtering i vores WPF-applikation.
using System.Windows;
using ChatMessageManager.Helpers;
using ChatMessageManager.Models;
using System.Collections.Generic;

namespace ChatMessageManager
{
    public partial class MainWindow : Window
    {
        private XmlParser xmlParser;
        private const string XmlFilePath = "Data/chatdata.xml"; // Dette er stien til vores XML-fil

        // Dette er konstruktøren for MainWindow, hvor vi initialiserer komponenterne og indlæser chatbeskeder fra XML-filen.
        public MainWindow()
        {
            InitializeComponent();
            xmlParser = new XmlParser(XmlFilePath);
            List<ChatMessage> chatMessages = xmlParser.ParseXml();

            // Her filtrerer vi chatbeskeder med humørerne "happy," "neutral," eller "sad."
            List<ChatMessage> happyMessages = new List<ChatMessage>();
            foreach (ChatMessage message in chatMessages)
            {
                if (message.Sentiment == "happy, neutral, sad")
                {
                    happyMessages.Add(message);
                }
            }

            // Vi sætter datakilden for ListView til de filtrerede chatbeskeder.
            ChatMessagesListView.ItemsSource = happyMessages;
        }
    }
}
