using System.Collections.Generic;
using System.Linq;

namespace Hapthorn.Services.ConsoleArguments
{
    public class ConsoleArgumentsManager
    {
        private List<string> Args { get; }

        public ConsoleArgumentsManager(string[] args)
        {
            Args = new List<string>();
            foreach (var arg in args)
            {
                Args.Add(arg.Trim().ToLowerInvariant());
            }
        }

        public string CommandName => Args.FirstOrDefault() ?? "web";
    }
}