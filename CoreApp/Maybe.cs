using LanguageExt;
using System;

namespace CoreApp
{
    [Union]
    public interface Maybe<A>
    {
        Maybe<A> Just(A value);
        Maybe<A> Nothing();
    }
}
