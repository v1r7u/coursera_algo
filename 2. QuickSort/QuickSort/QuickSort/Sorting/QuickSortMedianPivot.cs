namespace QuickSort.Sorting
{
    public sealed class QuickSortMedianPivot : QuickSortBase
    {
        public QuickSortMedianPivot(int[] array) : base(array)
        {
        }

        protected override int GetPivot(int left, int right)
        {
            int center = left + (right - left)/2;
            
            var leftEl = Array[left];
            var rightEl = Array[right];
            var centerEl = Array[center];
            
            if((leftEl < rightEl && leftEl > centerEl) || 
                (leftEl < centerEl && leftEl > rightEl))
                return left;

            if ((centerEl < rightEl && centerEl > leftEl) ||
                (centerEl < leftEl && centerEl > rightEl))
                return center;

            return right;
        }
    }
}