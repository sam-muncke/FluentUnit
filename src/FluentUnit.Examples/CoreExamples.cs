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
        public void TestReturnValue()
        {
            const string expected = "SomeString";

            Given.That(() => { })
                .And.That(() => _mockDependency.DependencyProperty = expected)
                .And.A.Subject(() =>  new Subject(_mockDependency))
                .When(subject => subject.ReturnSomething(0, "AnyValue"))
                .Then(result => Assert.That(result, Is.EqualTo(expected)));
        }

        [Test]
        public void TestMethodInvocation()
        {
            Given.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.DoSomething(0, "AnyValue"))
                .Then(() => Assert.That(_mockDependency.DependencyMethodWasCalled));
        }

        [Test]
        public void TestDelegatedMethodInvocation()
        {
            Given.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.ThrowException())
                .Then(action => Assert.Throws<Exception>(action.Invoke));
        }

        [Test]
        public void TestConstructor()
        {
            Given.A.Subject(() => new Subject(null))
                .WhenCreated()
                .Then(action => Assert.Throws<ArgumentNullException>(action.Invoke));
        }

        [Test]
        public async Task TestReturnValueFromAsyncMethod()
        {
           const string expected = "SomeString";

            await Given.That(() => _mockDependency.DependencyProperty = expected)
                .And.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.ReturnSomethingAsync(0, "AnyValue"))
                .Then(result => Assert.That(result, Is.EqualTo(expected)));
        }

        [Test]
        public async Task TestAsyncMethodInvocation()
        {
            await Given.A.Subject(() => new Subject(_mockDependency))
                .When(subject => subject.DoSomethingAsync(0, "AnyValue"))
                .Then(() => Assert.That(_mockDependency.DependencyMethodWasCalled));
        }
    }
}
