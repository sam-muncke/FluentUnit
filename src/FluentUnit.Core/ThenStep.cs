using System;

namespace FluentUnit.Core
{
    internal class ThenStep<TSubject,TResult> : IThen<TResult>
    {
        private readonly Action _arrange;
        private readonly Func<TSubject> _createSubject;
        private readonly Action<TSubject> _act;
        private TResult _result;

        public ThenStep(Action arrange, Func<TSubject> createSubject, Action<TSubject> act)
        {
            _arrange = arrange;
            _createSubject = createSubject;
            _act = act;
        }

        public ThenStep(Action arrange, Func<TSubject> createSubject, Func<TSubject, TResult> act)
        {
            _arrange = arrange;
            _createSubject = createSubject;
            _act = s => _result = act(s);
        }

        public void Then(Action<TResult> assert)
        {
            Then(() => assert(_result));
        }

        public void Then(Action assert)
        {
            _arrange();
            var subject = _createSubject();
            _act(subject);
            assert();
        }
    }
}