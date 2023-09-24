
namespace ExtensionForMyEnumerator
{
    public static class MyEnumerableExtension
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, double percent)
        {

            if (percent < 1 || percent > 100)
                throw new ArgumentException("collection is out of range 1 to 100", nameof(collection));

            var itemCount = collection.Count();

            var countPercent = (int)Math.Ceiling(itemCount * percent / 100);

            return collection.OrderByDescending(item => item).Take(countPercent);
        }
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, double percent, Func<T, int> func)
        {
            if (percent < 1 || percent > 100)
                throw new ArgumentException("collection is out of range 1 to 100", nameof(collection));

            var itemCount = collection.Count();

            var countPercent = (int)Math.Ceiling(itemCount * percent / 100);

            return collection.OrderByDescending(func).Take(countPercent);
        }
    }
}
