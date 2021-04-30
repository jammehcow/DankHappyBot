namespace DankHappyBot.Service.Configuration
{
    public class TwitchApiOptions : IPrefixedOptions
    {
        public string GetPrefix() => "TwitchApi";

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
