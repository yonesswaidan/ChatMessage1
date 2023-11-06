// Den bruges til at læse en XML-fil med chatbeskeder.
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ChatMessageManager.Models; // Her importerer vi ChatMessage-klassen

namespace ChatMessageManager.Helpers
{
    public class XmlParser
    {
        private string xmlFilePath;

        // Dette er konstruktøren for XmlParser. Den tager stien til XML-filen som input.
        public XmlParser(string filePath)
        {
            xmlFilePath = filePath;
        }

        // Dette er en metode til at læse XML-filen og gemme chatbeskeder i en liste.
        public List<ChatMessage> ParseXml()
        {
            List<ChatMessage> chatMessages = new List<ChatMessage>();

            try
            {
                // Her indlæses roden af XML-dokumentet.
                XElement xmlRoot = XElement.Load(xmlFilePath);

                // Vi går igennem hvert "message" element i XML-filen.
                foreach (XElement messageElement in xmlRoot.Elements("message"))
                {
                    // Her henter vi teksten fra "message" elementet.
                    string text = messageElement.Value;

                    // Vi tjekker "sentiment" attributten og bruger "neutral," hvis den ikke er til stede.
                    string sentiment = messageElement.Attribute("sentiment")?.Value ?? "neutral";

                    // Vi opretter et ChatMessage-objekt og tilføjer det til listen.
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
                // Her kunne vi håndtere fejl, som at logge dem eller kaste en exception.
            }

            // Til sidst returnerer vi listen over chatbeskeder.
            return chatMessages;
        }
    }
}


