using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Name = System.String;

namespace ClassLibrary1
{
    public class Robot<A>
    {
        public A Value { get; }
        public Robot(A a)
        {
            Value = a;
        }
    }

    public static class MRobot
    {
        public static Robot<A> Return<A>(A value) => 
            new Robot<A>(value);

        public static Robot<B> Bind<A, B>(this Robot<A> ma, Func<A, Robot<B>> f) =>
            f(ma.Value);

        public static Robot<B> Map<A, B>(this Robot<A> ma, Func<A, B> f) =>
            Bind(ma, x => Return(f(x)));

        public static Robot<B> Select<A, B>(this Robot<A> ma, Func<A, B> f) =>
            Bind(ma, x => Return(f(x)));

        public static Robot<B> SelectMany<A, B>(this Robot<A> ma, Func<A, Robot<B>> f) =>
            Bind(ma, f);

        public static Robot<C> SelectMany<A, B, C>(this Robot<A> ma, Func<A, Robot<B>> bind, Func<A, B, C> project) =>
            ma.Bind(a => bind(a).Map(b => project(a, b)));
    }
}
