namespace Util
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns a random item from the array
        /// </summary>
        public static T Random<T>(this T[] arr)
        {
            if(arr.Length < 1)
                return default;

            return arr[Rng.Next(arr.Length - 1)];
        }
    }
}