namespace CSharp_Ex.Common.Enums
{
    public enum FeeType
    {
        Manual,
        Fast
    }

    public static class FeeTypeExtensions
    {
        private static readonly Dictionary<FeeType, int> FeeMapping = new()
        {
            { FeeType.Manual, 3000 },
            { FeeType.Fast, 5000 }
        };

        public static int GetFee(FeeType feeType)
        {
            return FeeMapping.TryGetValue(feeType, out var fee) ? fee : 0;
        }
    }
}