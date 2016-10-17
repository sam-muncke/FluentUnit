using System;

namespace FluentUnit.Core
{
    public interface IGiven
    {
        PostGivenThat That(Action setup);
        PostGivenA A { get; }
    }
}