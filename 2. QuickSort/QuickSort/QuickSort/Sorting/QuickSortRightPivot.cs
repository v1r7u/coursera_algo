namespace QuickSort.Sorting
{
    public sealed class QuickSortRightPivot : QuickSortBase
    {
        public QuickSortRightPivot(int[] array) : base(array)
        {
        }

        protected override int GetPivot(int left, int right)
        {
            return right;
        }
    }
}