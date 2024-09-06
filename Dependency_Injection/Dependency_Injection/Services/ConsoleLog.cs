using Dependency_Injection.Services.Interfaces;

namespace Dependency_Injection.Services
{
    public class ConsoleLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("ErrorMessage");
        }
    }
}
