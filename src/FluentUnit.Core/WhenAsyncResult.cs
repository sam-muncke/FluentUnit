using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    public class WhenAsyncResult<TSubject, TResult> : WhenAsync<TSubject>
    {
        private Task<TResult> _result;

        public WhenAsyncResult(Func<TSubject> creationDelegate, IList<Action> setupActions, Func<TSubject, Task<TResult>> getResult) 
            : base(creationDelegate, setupActions)
        {
            Action = s => _result = getResult(s);
        }

        public async Task Then(Action<TResult> assertOnResult)
        {
            await Then(async () => assertOnResult(await _result));
        }
    }
}