namespace QuickSort.Sorting
{
    public abstract class QuickSortBase
    {
        protected int[] Array;

        protected QuickSortBase(int[] array)
        {
            Array = new int[array.Length];
            array.CopyTo(Array, 0);
        }

        public long Sort()
        {
            return Sort(0, Array.Length - 1);
        }

        private long Sort(int left, int right)
        {
            int legth = right - left;
            if (legth < 1)
            {
                return 0;
            }

            FindAndMovePivot(left, right);
            int pivotPos = Order(left, right);

            long result = legth;
            result += Sort(left, pivotPos - 1);
            result += Sort(pivotPos + 1, right);

            return result;
        }

        private void FindAndMovePivot(int left, int right)
        {
            int pivotPos = GetPivot(left, right);
            Swap(left, pivotPos);
        }

        protected abstract int GetPivot(int left, int right);

        private int Order(int left, int right)
        {
            int p = Array[left];
            int i = left + 1;
            for (int j = left + 1; j <= right; j++)
            {
                if (Array[j] < p)
                {
                    Swap(j, i);
                    i++;
                }
            }
            Swap(left, i - 1);
            return i - 1;
        }

        private void Swap(int i, int j)
        {
            if(i == j)
                return;

            var left = Array[i];
            Array[i] = Array[j];
            Array[j] = left;
        }
    }
}