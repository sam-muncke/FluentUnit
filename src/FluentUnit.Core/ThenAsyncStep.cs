using System;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    internal class ThenAsyncStep<TSubject, TResult> : IThenAsync<TResult>
    {
        private readonly Action _arrange;
        private readonly Func<TSubject> _createSubject;
        private readonly Func<TSubject, Task> _act;
        private Task<TResult> _result;

        public ThenAsyncStep(Action arrange, Func<TSubject> createSubject, Func<TSubject, Task> act)
        {
            _arrange = arrange;
            _createSubject = createSubject;
            _act = act;
        }

        public ThenAsyncStep(Action arrange, Func<TSubject> createSubject, Func<TSubject, Task<TResult>> act)
        {
            _arrange = arrange;
            _createSubject = createSubject;
            _act = s => _result = act(s);
        }

        public async Task Then(Action<TResult> assert)
        {
            await Then(async () => assert(await _result));
        }

        public async Task Then(Action assert)
        {
            _arrange();
            var subject = _createSubject();
            await _act(subject);
            assert();
        }
    }
}