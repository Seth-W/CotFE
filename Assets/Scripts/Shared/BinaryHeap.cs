using UnityEngine;

public class BinaryHeap_Min<T>
{
    BinaryHeap_Min_Wrapper<T>[] heap;
    int numberOfElements;

    public bool isEmpty
    {
        get { return numberOfElements == 0; }
    }

    public BinaryHeap_Min()
    {
        heap = new BinaryHeap_Min_Wrapper<T>[1];
        numberOfElements = 0;
    }

    public void Enqueue(T newNode, int key)
    {
        if (numberOfElements >= heap.Length)
            expandHeap();

        heap[numberOfElements] = new BinaryHeap_Min_Wrapper<T>(newNode, key);

        int childIndex = numberOfElements;

        while(childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;
            if (heap[parentIndex].CompareTo(heap[childIndex]) <= 0)
                break;
            swap(childIndex, parentIndex);
            childIndex = parentIndex;
        }
        numberOfElements += 1;
    }

    public T Dequeue()
    {
        T min = heap[0].getObj();

        heap[0] = heap[numberOfElements - 1];
        numberOfElements -= 1;

        int index = 0;

        while(index < numberOfElements)
        {
            int leftIndex = (2 * index) + 1;
            int rightIndex = (2 * index) + 2;

            if (leftIndex >= numberOfElements)
                break;

            int minChildIndex;
            if (rightIndex >= numberOfElements)
                minChildIndex = leftIndex;
            else
            {
                if (heap[leftIndex].CompareTo(heap[rightIndex]) < 0)
                    minChildIndex = leftIndex;
                else
                    minChildIndex = rightIndex;
            }

            if (heap[index].CompareTo(heap[minChildIndex]) < 0)
                break;

            swap(index, minChildIndex);
            index = minChildIndex;
        }

        return min;
    }


    void expandHeap()
    {
        BinaryHeap_Min_Wrapper<T>[] temp = new BinaryHeap_Min_Wrapper<T>[numberOfElements + 1];
        for (int i = 0; i < heap.Length; i++)
        {
            Debug.Log(i);
            temp[i] = heap[i];
        }
        heap = temp;
    }

    void swap(int child, int parent)
    {
        BinaryHeap_Min_Wrapper<T> temp = heap[parent];
        heap[parent] = heap[child];
        heap[child] = temp;
    }

    public class BinaryHeap_Min_Wrapper<T>
    {
        T storedObj;
        int keyField;

        public BinaryHeap_Min_Wrapper(T obj, int key)
        {
            storedObj = obj;
            keyField = key;
        }

        public int CompareTo(BinaryHeap_Min_Wrapper<T> other)
        {
            return keyField - other.keyField;
        }

        public T getObj()
        {
            return storedObj;
        }
    }
}
