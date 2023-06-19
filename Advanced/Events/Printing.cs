using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Events
{
    public class Printing
    {
        public static void Print()
        {
            Subscriber subscriber = new Subscriber();
            Publisher publisher = new Publisher();

            publisher.myEvent += subscriber.Add;
            publisher.RaiseEvent(10, 20);

            AutoImplementedEvent autoImplementedEvent = new AutoImplementedEvent();
            autoImplementedEvent.myAutoEvent += subscriber.Add;
            autoImplementedEvent.RaiseAutoEvent(100, 20);

            // anonymous method
            publisher.myEvent += delegate(int a, int b)
            {
                int c = a * b;
                Console.WriteLine(c);
            };

            // lambda expression
/*            publisher.myEvent += (a, b) =>
            {
                int c = a / b;
                return c;
            };*/

            // inline lambda expression
/*            publisher.myEvent += (a, b) => a * b;*/
        }
    }
}
