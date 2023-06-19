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

            FuncDelegate funcMethod = new FuncDelegate();
            funcMethod.myEvents += (a, b) => 
            {
                int c = a * b;
                return c; 
            };

            Console.WriteLine(funcMethod.RaiseEvent(30, 10));

            ActionDelegate actionDelegate = new ActionDelegate();
            actionDelegate.myAction += (a,b) =>
            {
                int c = a + b;
                Console.WriteLine(c);
            };

            actionDelegate.RaiseEvent(40, 40);
            
            PredicateDelegate predicateDelegate = new PredicateDelegate();
            predicateDelegate.myPredicate += (a) =>
            {
                return a >= 0;
            };

            Console.WriteLine(predicateDelegate.RaiseEvent(10));
            Console.WriteLine(predicateDelegate.RaiseEvent(-10));

            Printing print = new Printing();
            print.CustomEventArg();

            Student s = new Student() { StudentName = "Scott" };
            Console.WriteLine(s.GetStudentNameLength());
            Console.WriteLine(s.StudentName);

            SwitchExpression one = new SwitchExpression();
            one.Switch(3);

/*            // inline lambda expression
            publisher.myEvent += (a, b) => a * b;*/
        }

        public void CustomEventArg()
        {
            Publish publish = new Publish();
            publish.myEvent += (sender, e) => 
            {
                int c = e.a + e.b;
                Console.WriteLine(c);
            };
            publish.RaiseEvent(this, 10, 200);
        }
    }
}
