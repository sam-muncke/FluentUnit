using System;
using System.Collections.Generic;

namespace FluentUnit.Core
{
    public class Given : IGiven
    {
        private readonly IList<Action> _setupActions = new List<Action>();

        private Given()
        {
        }

        public static PostGivenA A => ((IGiven)new Given()).A;

        public static PostGivenThat That(Action setup)
        {
            IGiven given = new Given();
            return given.That(setup);
        }

        PostGivenThat IGiven.That(Action setup)
        {
            _setupActions.Add(setup);
            return new PostGivenThat(this);
        }

        PostGivenA IGiven.A => new PostGivenA(_setupActions);
    }
}