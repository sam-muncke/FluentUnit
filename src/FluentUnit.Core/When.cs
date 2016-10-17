using System;
using System.Collections.Generic;

namespace FluentUnit.Core
{
    public class When<TSubject>
    {
        private readonly Func<TSubject> _creationDelegate;
        private readonly IList<Action> _setupActions;
        protected Action<TSubject> Action;

        protected When(Func<TSubject> creationDelegate, IList<Action> setupActions)
        {
            _creationDelegate = creationDelegate;
            _setupActions = setupActions;
        }

        public When(Func<TSubject> creationDelegate, IList<Action> setupActions, Action<TSubject> action)
            : this(creationDelegate, setupActions)
        {
            Action = action;
        }

        public void Then(Action assert)
        {
            var subject = Arrange();

            Action.Invoke(subject);

            assert.Invoke();
        }

        public void Then(Action<Action> assert)
        {
            var subject = Arrange();

            assert.Invoke(() => Action.Invoke(subject));
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