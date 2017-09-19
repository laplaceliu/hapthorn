using System;
using System.Data;
using Hapthorn.Services.Migrations;
using Moq;
using Should;
using Xunit;

namespace Hapthorn.Test.Services.Migrations
{
    public class MigrationRunnerSpecs
    {
        private IDbConnection DbConnection => Mock.Of<IDbConnection>();
        private MigrationRunner Subject => new MigrationRunner(DbConnection);

        [Fact]
        public void ShouldBeCreatable() => Subject.ShouldNotBeNull();

        [Fact]
        public void ShouldBeAbleToAddAnAssemblyToTheSearchList()
        {
            var assembly = this.GetType().Assembly;
            Subject.FromAssembly(assembly);
            Console.WriteLine("Contains [{0}] Assemblies", Subject.MigrationAssemblies.Count);
            foreach(var asm in Subject.MigrationAssemblies){
                Console.WriteLine("Assembly: " + asm.ToString());
            }
            Subject.MigrationAssemblies.ShouldContain(assembly);
        }
    }
}