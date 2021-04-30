namespace DankHappyBot.Service.Configuration
{
    public class IrcOptions : IPrefixedOptions
    {
        public string GetPrefix() => "Irc";

        public ConnectionSection Connection { get; set; }
        public CredentialsSection Credentials { get; set; }

        public class ConnectionSection
        {
            public string Address { get; set; }
            public int Port { get; set; }
        }

        public class CredentialsSection
        {
            public string Username { get; set; }
            public string OAuthToken { get; set; }
        }
    }
}
