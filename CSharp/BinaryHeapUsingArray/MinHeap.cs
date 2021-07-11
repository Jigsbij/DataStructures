
using System;

namespace CSharp.BinaryHeapUsingArray
{
    public class MinHeap: BinaryHeap
    {
        public MinHeap(int capacity): base(capacity)
        {

        }
        
        protected override void ReCalculateUp()
        {
            int index = size - 1;
            while (!IsRoot(index) && elements[index] < GetParent(index))
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
                int smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
                    smallerIndex = GetRightChildIndex(index);

                if (elements[smallerIndex] >= elements[index])
                    break;
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }
    }
}
