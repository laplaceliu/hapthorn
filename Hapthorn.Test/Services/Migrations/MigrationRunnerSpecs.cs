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
        private static IDbConnection DbConnection => Mock.Of<IDbConnection>();
        private readonly MigrationRunner Subject = new MigrationRunner(DbConnection);

        [Fact]
        public void ShouldBeCreatable() => Subject.ShouldNotBeNull();

        [Fact]
        public void ShouldBeAbleToAddAnAssemblyToTheSearchList()
        {
            var assembly = this.GetType().Assembly;
            Subject.FromAssembly(assembly);
            Subject.MigrationAssemblies.ShouldContain(assembly);
        }
    }
}