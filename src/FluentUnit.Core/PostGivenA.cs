using System;
using System.Collections.Generic;

namespace FluentUnit.Core
{
    public class PostGivenA
    {
        private readonly IList<Action> _setupActions;

        public PostGivenA(IList<Action> setupActions)
        {
            _setupActions = setupActions;
        }

        public PostGiven<TSubject> Subject<TSubject>(Func<TSubject> creationDelegate)
        {
            return new PostGiven<TSubject>(_setupActions, creationDelegate);
        }

    }
}