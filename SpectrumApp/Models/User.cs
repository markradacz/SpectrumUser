using SQLite;

namespace SpectrumApp
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Ignore]
        public string MaskedPassword { get { return LocaleConstants.MaskedChars; } }
    }
}
