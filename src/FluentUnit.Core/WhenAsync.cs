using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentUnit.Core
{
    public class WhenAsync<TSubject>
    {
        private readonly Func<TSubject> _creationDelegate;
        private readonly IList<Action> _setupActions;
        protected Func<TSubject, Task> Action;

        protected WhenAsync(Func<TSubject> creationDelegate, IList<Action> setupActions)
        {
            _creationDelegate = creationDelegate;
            _setupActions = setupActions;
        }

        public WhenAsync(Func<TSubject> creationDelegate, IList<Action> setupActions, Func<TSubject, Task> action)
            : this(creationDelegate, setupActions)
        {
            Action = action;
        }

        public async Task Then(Action assert)
        {
            var subject = Arrange();
            await Action.Invoke(subject);
            assert.Invoke();
        }

        private TSubject Arrange()
        {
            foreach (var action in _setupActions)
            {
                action.Invoke();
            }

            return _creationDelegate.Invoke();
        }
    }
}