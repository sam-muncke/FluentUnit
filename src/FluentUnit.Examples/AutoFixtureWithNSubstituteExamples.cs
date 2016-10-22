using FluentAssertions;
using FluentUnit.AutoFixture;
using FluentUnit.Core;
using FluentUnit.Examples.TestObjects;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.NUnit3;

namespace FluentUnit.Examples
{
    [TestFixture]
    public class AutoFixtureWithNSubstituteExamples
    {
        private IFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture()
                .Customize(new AutoNSubstituteCustomization());
        }

        [Test, AutoData]
        public void TestFixtureExtensions(string expectedValue)
        {
            Given.A.Fixture(_fixture)
                .With<IDependency>(dependency => dependency.DependencyProperty.Returns(expectedValue))
                .And.WithSubject<Subject>()
                .When(subject => subject.ReturnSomething(Arg.Any<int>(), Arg.Any<string>()))
                .Then(result => result.Should().Be(expectedValue));
        }
    }
}
