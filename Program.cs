
namespace Shiro 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            Config config = Config.Read("./../../../Config/config.json");

            Bot bot = new Bot(config);

            bot.Run().GetAwaiter().GetResult();
        }
    }
}