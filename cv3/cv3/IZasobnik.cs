using System.Dynamic;

namespace cv3 {
    public interface IZasobnik<T>:IADT {
        void Push(T number);
        T Pop();
        T Top { get; }
    }
}