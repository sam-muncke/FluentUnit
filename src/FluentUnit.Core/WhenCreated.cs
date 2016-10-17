using System;
using System.Collections.Generic;

namespace FluentUnit.Core
{
    public class WhenCreated<TSubject> : When<TSubject>
    {
        public WhenCreated(Func<TSubject> creationDelegate, IList<Action> setupActions) 
            : base(() => default(TSubject), setupActions, subject => creationDelegate())
        {
        }
    }
}