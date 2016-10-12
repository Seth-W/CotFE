public class PriorityQueue<T>
{
    PriorityQueueWrapper<T> header;
    public bool isEmpty
    {
        get { return header == null; }
    }

    public void Enqueue(T newNode, int priorityValue)
    {
        PriorityQueueWrapper<T> p = header;
        PriorityQueueWrapper<T> newWrapper = new PriorityQueueWrapper<T>(newNode, priorityValue);

        if (header == null)
        {
            header = newWrapper;
        }
        else
        {
            while (p != null && newWrapper.compareTo(p) >= 0)
            {
                p = p.nextNode;
            }
            if (p == null)
            {
                header = newWrapper;
            }
            else
            {
                newWrapper.nextNode = p.nextNode;
                p.nextNode = newWrapper;
            }
        }
    }

    public T Dequeue()
    {
        PriorityQueueWrapper<T> retValue;
        retValue = header;

        if (header != null)
            header = header.nextNode;

        else
            return default(T);

        return retValue.obj;
    }

    public T Peek()
    {
        return header.obj;
    }


    class PriorityQueueWrapper<T>
    {
        int priorityValue;
        public T obj;
        public PriorityQueueWrapper<T> nextNode;

        public PriorityQueueWrapper(T obj, int priorityValue)
        {
            this.priorityValue = priorityValue;
            this.obj = obj;
            nextNode = null;
        }

        public int compareTo(PriorityQueueWrapper<T> targetKey)
        {
            return priorityValue - targetKey.priorityValue;
        }

        public T getObject()
        {
            return obj;
        }
    }
}