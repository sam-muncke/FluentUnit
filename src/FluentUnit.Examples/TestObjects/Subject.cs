using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentUnit.Examples.TestObjects
{
    public class Subject
    {
        private readonly IDependency _dependency;

        public Subject(IDependency dependency)
        {
            if(dependency == null)
                throw new ArgumentNullException(nameof(dependency));

            _dependency = dependency;
        }

        public void DoSomething(int someValue, string someString)
        {
            _dependency.DependencyMethod();
        }

        public async Task DoSomethingAsync(int someValue, string someString)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                _dependency.DependencyMethod();
            });
        }

        public object ReturnSomething(int someValue, string someString)
        {
            return _dependency.DependencyProperty;
        }

        public async Task<object> ReturnSomethingAsync(int someValue, string someString)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return _dependency.DependencyProperty;
            });
        }

        public void ThrowException()
        {
            throw new Exception();
        }
    }
}