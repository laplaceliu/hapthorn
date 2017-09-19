using Hapthorn.Services.ConsoleArguments;
using Should;
using Xunit;

namespace Hapthorn.Test.Services.ConsoleArguments
{
    public class ConsoleArgumentsManagerSpecs
    {
        private static ConsoleArgumentsManager ConsoleArgumentsManagerEmptyArgs => new ConsoleArgumentsManager(new string[0]);
        private static ConsoleArgumentsManager ConsoleArgumentsManagerDefaultArgs => new ConsoleArgumentsManager(new [] { "xunit" });
        
        [Fact] 
        public void CommandNameIsNullIfNoArgs() =>
            ConsoleArgumentsManagerEmptyArgs.CommandName.ShouldEqual("web");

        [Fact]
        public void CommandName_IsTheFirstArg() =>
            ConsoleArgumentsManagerDefaultArgs.CommandName.ShouldEqual("xunit");
    }
}