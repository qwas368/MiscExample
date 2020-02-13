using LanguageExt;
using System;

namespace ConsoleApp2.Monad
{
    public delegate A Reader<Env, A>(Env env);

    public static class Reader
    {
        public static Reader<Env, A> Return<Env, A>(A value) =>
            _ => value;

        public static Reader<Env, B> Bind<Env, A, B>(this Reader<Env, A> ma, Func<A, Reader<Env, B>> f) =>
            env =>
                f(ma(env))(env);

        public static Reader<Env, B> Select<Env, A, B>(this Reader<Env, A> ma, Func<A, B> f) =>
            ma.Bind(a => Return<Env, B>(f(a)));

        public static Reader<Env, C> SelectMany<Env, A, B, C>(
            this Reader<Env, A> ma,
            Func<A, Reader<Env, B>> bind,
            Func<A, B, C> project) =>
                ma.Bind(a => bind(a).Select(b => project(a, b)));

        public static Reader<Env, Env> Ask<Env>() =>
            env => env;

        public static Reader<World, string[]> ReadAllLines(string fileName) =>
            from env in Ask<World>()
            select env.ReadAllLines(fileName);

        public static Reader<World, Unit> WriteAllLines(string fileName, string[] lines) =>
            from env in Ask<World>()
            select env.WriteAllLines(fileName, lines);
    }
}
