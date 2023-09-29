using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ChatMessageManager.Models; // Tilføj denne linje for at importere ChatMessage-klassen

namespace ChatMessageManager.Helpers
{
    public class XmlParser
    {
        private string xmlFilePath;

        public XmlParser(string filePath)
        {
            xmlFilePath = filePath;
        }

        public List<ChatMessage> ParseXml()
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();

            try
            {
                XElement xmlRoot = XElement.Load(xmlFilePath);

                foreach (XElement messageElement in xmlRoot.Elements("message"))
                {
                    string text = messageElement.Value;
                    string sentiment = messageElement.Attribute("sentiment")?.Value ?? "neutral";

                    ChatMessage chatMessage = new ChatMessage
                    {
                        Text = text,
                        Sentiment = sentiment
                    };

                    chatMessages.Add(chatMessage);
                }
            }
            catch (Exception ex)
            {
                // Håndter fejl, f.eks. log eller kast en exception
            }

            return chatMessages;
        }
    }
}
