namespace Kuchejda.ZTP.WebApi.Extensions
{
    public static class DistinctByExtension
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
                (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var known = new HashSet<TKey>();
            return source.Where(element => known.Add(keySelector(element)));
        }
    }
}
