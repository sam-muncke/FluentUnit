using System;
using System.Threading.Tasks;
using FluentUnit.Core;
using FluentUnit.Examples.TestObjects;
using NUnit.Framework;

namespace FluentUnit.Examples
{
    [TestFixture]
    public class CoreExamples
    {
        private MockDependency _mockDependency;

        [SetUp]
        public void SetUp()
        {
            _mockDependency = new MockDependency();
        }

        [Test]
        public void Testing_A_Returned_Value()
        {
            const string expected = "SomeString";

            Given.A.Context(() => _mockDependency.DependencyProperty = expected)
                .And.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.ReturnSomething(0, "AnyValue"))
                .Then(result => Assert.That(result, Is.EqualTo(expected)));
        }

        [Test]
        public void Testing_A_Method_Invocation()
        {
            Given.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.DoSomething(0, "AnyValue"))
                .Then(() => Assert.That(_mockDependency.DependencyMethodWasCalled));
        }

        [Test]
        public void Testing_A_Delegated_Method_Invocation()
        {
            Given.A.Subject(() => new Subject(_mockDependency))
                .When<Action>(subject => () => subject.ThrowException())
                .Then(action => Assert.Throws<Exception>(action.Invoke));
        }

        [Test]
        public void Testing_A_Constructor()
        {
            Given.A.Subject(() => new Subject(null))
                .WhenCreated()
                .Then(action => Assert.Throws<ArgumentNullException>(action.Invoke));
        }

        [Test]
        public async Task Testing_A_Returned_Value_From_An_Async_Method()
        {
            const string expected = "SomeString";

            await Given.A.Context(() => _mockDependency.DependencyProperty = expected)
                .And.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.ReturnSomethingAsync(0, "AnyValue"))
                .Then(result => Assert.That(result, Is.EqualTo(expected)));
        }

        [Test]
        public async Task Testing_An_Async_Method_Invocation()
        {
            await Given.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.DoSomethingAsync(0, "AnyValue"))
                .Then(() => Assert.That(_mockDependency.DependencyMethodWasCalled));
        }
    }
}
