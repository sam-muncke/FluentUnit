using System;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    internal class WhenStep<TSubject> : IWhen<TSubject>
    {
        private readonly Action _arrange;
        private readonly Func<TSubject> _createSubject;

        public WhenStep(Action arrange, Func<TSubject> createSubject)
        {
            _arrange = arrange;
            _createSubject = createSubject;
        }

        public IThen When(Action<TSubject> act)
        {
            return new ThenStep<TSubject, object>(_arrange, _createSubject, act);
        }

        public IThen<TResult> When<TResult>(Func<TSubject, TResult> act)
        {
            return new ThenStep<TSubject, TResult>(_arrange, _createSubject, act);
        }

        public IThenAsync When(Func<TSubject, Task> act)
        {
            return new ThenAsyncStep<TSubject, object>(_arrange, _createSubject, act);
        }

        public IThenAsync<TResult> When<TResult>(Func<TSubject, Task<TResult>> act)
        {
            return new ThenAsyncStep<TSubject, TResult>(_arrange, _createSubject, act);
        }

        public IThen<Action> WhenCreated()
        {
            return new ThenStep<object, Action>(_arrange, () => null, _ => () => _createSubject());
        }
    }
}