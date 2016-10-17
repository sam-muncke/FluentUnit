using System;
using System.Collections.Generic;

namespace FluentUnit.Core
{
    public class WhenResult<TSubject, TResult> : When<TSubject>
    {
        private TResult _result;

        public WhenResult(Func<TSubject> creationDelegate, IList<Action> setupActions, Func<TSubject, TResult> getResult) 
            : base(creationDelegate, setupActions)
        {
            Action = s => _result = getResult(s);
        }

        public void Then(Action<TResult> assertOnResult)
        {
            Then(() => assertOnResult(_result));
        }
    }
}