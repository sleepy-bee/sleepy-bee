using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Extensions
{
    public static class EnumerableHelper
    {
        private static readonly Random _random = new Random();

        public static T Random<T>(this IEnumerable<T> source) => source.Random(_random);

        public static T Random<T>(this IEnumerable<T> source, Random random) => source.ElementAt(random.Next(source.Count()));
    }
}
