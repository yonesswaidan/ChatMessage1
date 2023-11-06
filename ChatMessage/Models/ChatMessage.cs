// Den repræsenterer en chatbesked med tekst og følelse.
namespace ChatMessageManager.Models
{
    public class ChatMessage
    {
        // Dette er en egenskab for selve teksten i chatbeskeden.
        public string Text { get; set; }

        // Og dette er en egenskab for følelsen (sentiment) i chatbeskeden.
        public string Sentiment { get; set; }
    }
}
