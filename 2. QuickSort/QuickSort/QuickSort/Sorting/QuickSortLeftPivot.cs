namespace QuickSort.Sorting
{
    public sealed class QuickSortLeftPivot : QuickSortBase
    {
        public QuickSortLeftPivot(int[] array) : base(array)
        {
        }

        protected override int GetPivot(int left, int right)
        {
            return left;
        }
    }
}