using System;

namespace CSharp.BinaryHeapUsingArray
{
    public class MaxHeap:BinaryHeap
    {
        public MaxHeap(int capacity): base(capacity)
        {
        }
        protected override void ReCalculateUp()
        {
            int index = size - 1;

            while (!IsRoot(index) && elements[index] > GetParent(index))
            {
                int parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        protected override void ReCalculateDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int largerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                    largerIndex = GetRightChildIndex(index);

                if (elements[largerIndex] < elements[index])
                    break;
                Swap(largerIndex, index);
                index = largerIndex;
            }
        }
    }
}
