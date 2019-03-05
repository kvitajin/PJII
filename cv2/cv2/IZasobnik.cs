using System.Dynamic;

namespace cv2 {
    public interface IZasobnik:IADT {
        void Push(int number);
        int Pop();
        int Top { get; }
    }
}