using BookApp.Debugging;

namespace BookApp
{
    public class BookAppConsts
    {
        public const string LocalizationSourceName = "BookApp";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "2b914fb89e5945e79daff876b406ce78";
    }
}
