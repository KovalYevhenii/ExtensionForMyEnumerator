namespace ExtensionForGetMaxMethod;
public static class MyGetMaxExtension
{
    public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> converter)
        where T : class
    {
        if (collection == null || !collection.Any())
            throw new ArgumentException("Collection is Null or Empty");
        return collection.Aggregate((maxItem, nextItem) => converter(nextItem) > converter(maxItem) ? nextItem : maxItem);
    }
}
