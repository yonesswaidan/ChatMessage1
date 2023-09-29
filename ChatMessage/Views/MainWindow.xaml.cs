using System.Windows;
using ChatMessageManager.Helpers;
using ChatMessageManager.Models;
using System.Collections.Generic;

namespace ChatMessageManager
{
    public partial class MainWindow : Window
    {
        private XmlParser xmlParser;
        private const string XmlFilePath = "Data/chatdata.xml"; // Henvisning XML filen

        public MainWindow()
        {
            InitializeComponent();
            xmlParser = new XmlParser(XmlFilePath);
            List<ChatMessage> chatMessages = xmlParser.ParseXml();                                                                                                                      

            // HUmør henvisningerne 
            List<ChatMessage> happyMessages = new List<ChatMessage>();
            foreach (ChatMessage message in chatMessages)
            {
                if (message.Sentiment == "happy, neutral, angry")
                {
                    happyMessages.Add(message);
                }
            }

            ChatMessagesListView.ItemsSource = happyMessages;
        }
    }
}
