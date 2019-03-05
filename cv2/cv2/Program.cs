using System;

namespace cv2 {
    class Program {
        static void Main(string[] args) {
            MujZasobnik z = new MujZasobnik(5);
            try {
                z.Pop();
            }
            catch (StackIsEmptyException e) {
                Console.WriteLine("Zachzceno");
                throw;
            }
            catch (Exception e) {
                Console.WriteLine("Obecna");
            }
            
            z.Push(5);
            z.Push(10);
            Console.WriteLine(z.Top);
        }
    
       
    } 
}