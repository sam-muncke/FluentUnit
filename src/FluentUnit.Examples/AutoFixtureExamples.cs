using System;
using FluentUnit.AutoFixture;
using FluentUnit.Core;
using FluentUnit.Examples.TestObjects;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace FluentUnit.Examples
{
    [TestFixture]
    public class AutoFixtureExamples
    {
        private IFixture _fixture;
        private IGivenAFixture _givenAFixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture()
                .Customize(new FreezingCustomization(typeof(MockDependency), typeof(IDependency)));

            _givenAFixture = Given.A.Fixture(_fixture);
        }
        
        [Test]
        public void Testing_A_Returned_Value()
        {
            const string expected = "SomeString";

            _givenAFixture
                .With<MockDependency>(dependency => dependency.DependencyProperty = expected)
                .And.WithSubject<Subject>()
                .When(subject => subject.ReturnSomething(_fixture.Create<int>(), _fixture.Create<string>()))
                .Then(result => Assert.That(result, Is.EqualTo(expected)));
        }

        [Test]
        public void Testing_A_Method_Invocation()
        {
            var mockDependency = _fixture.Create<MockDependency>();

            _givenAFixture
                .With(mockDependency)
                .And.WithSubject<Subject>()
                .When(subject => subject.DoSomething(_fixture.Create<int>(), _fixture.Create<string>()))
                .Then(() => Assert.That(mockDependency.DependencyMethodWasCalled));
        }

        [Test]
        public void Testing_A_Delegated_Method_Invocation()
        {
            _givenAFixture
                .WithSubject<Subject>()
                .When<Action>(subject => () => subject.ThrowException())
                .Then(action => Assert.Throws<Exception>(action.Invoke));
        }
    }
}
