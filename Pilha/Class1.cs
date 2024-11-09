namespace Pilha
{
    public class Pilha<T>
    {
        private readonly List<T> elementos = new List<T>();

        public void Push(T item)
        {
            elementos.Add(item);
        }

        public T Pop()
        {
            if (elementos.Count == 0)
                throw new InvalidOperationException("A pilha está vazia.");

            T item = elementos[^1];
            elementos.RemoveAt(elementos.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (elementos.Count == 0)
                throw new InvalidOperationException("A pilha está vazia.");

            return elementos[^1];
        }

        public int Count => elementos.Count;
    }
}
