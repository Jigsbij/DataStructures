using System;

namespace CSharp.BinaryHeapUsingArray
{
    public abstract class BinaryHeap
    {
        protected readonly int[] elements;
        public int Size { get { return size; }  }
        protected int size;
        protected BinaryHeap(int capacity)
        {
            elements = new int[capacity];
        }
        protected int GetLeftChildIndex(int index) => 2 * index + 1;
        protected int GetRightChildIndex(int index) => 2 * index + 2;
        protected int GetParentIndex(int index) => (index - 1) / 2;

        protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < size;
        protected bool HasRightChild(int index) => GetRightChildIndex(index) < size;
        protected bool IsRoot(int index) => index == 0;

        protected int GetLeftChild(int index) => elements[GetLeftChildIndex(index)];
        protected int GetRightChild(int index) => elements[GetRightChildIndex(index)];
        protected int GetParent(int index) => elements[GetParentIndex(index)];

        protected void Swap(int firstIndex, int secondIndex)
        {
            int temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public int Peek()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();
            return elements[0];
        }
        public int Pop()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();
            int rvalue = elements[0];
            elements[0] = elements[size - 1];
            size--;
            ReCalculateDown();
            return rvalue;
        }
        public void Add(int element)
        {
            if (size == elements.Length)
            {
                throw new IndexOutOfRangeException();
            }
            elements[size] = element;
            size++;
            ReCalculateUp();
        }

        protected abstract void ReCalculateUp();

        protected abstract void ReCalculateDown();
    }
}
