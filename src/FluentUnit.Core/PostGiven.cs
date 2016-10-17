using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    public class PostGiven<TSubject>
    {
        private readonly Func<TSubject> _creationDelegate;
        private readonly IList<Action> _setupActions;

        internal PostGiven(IList<Action> setupActions, Func<TSubject> creationDelegate)
        {
            _creationDelegate = creationDelegate;
            _setupActions = setupActions;
        }

        public When<TSubject> When(Action<TSubject> action)
        {
            return new When<TSubject>(_creationDelegate, _setupActions, action);
        }

        public WhenAsync<TSubject> When(Func<TSubject, Task> action)
        {
            return new WhenAsync<TSubject>(_creationDelegate, _setupActions, action);
        }

        public WhenResult<TSubject, TResult> When<TResult>(Func<TSubject, TResult> getResult)
        {
            return new WhenResult<TSubject, TResult>(_creationDelegate, _setupActions, getResult);
        }

        public WhenAsyncResult<TSubject, TResult> When<TResult>(Func<TSubject, Task<TResult>> getResult)
        {
            return new WhenAsyncResult<TSubject, TResult>(_creationDelegate, _setupActions, getResult);
        }

        public WhenCreated<TSubject> WhenCreated()
        {
            return new WhenCreated<TSubject>(_creationDelegate, _setupActions);
        }
    }
}