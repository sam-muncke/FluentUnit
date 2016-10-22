using FluentUnit.Core;
using Ploeh.AutoFixture;

namespace FluentUnit.AutoFixture
{
    public static class GivenExtensions
    {
        public static IGivenAFixture Fixture(this IGiven given, IFixture fixture)
        {
            return new GivenAFixture(given, fixture);
        }
    }
}