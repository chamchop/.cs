using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.PatternMatching
{
    public class Printing
    {

        public static void Print()
        {
            ParentClass _parentClass;
            _parentClass = new ChildClass() { x = 10, y = 20 };
            Console.WriteLine(_parentClass.x);

            if (_parentClass is ChildClass)
            {
                ChildClass _childClass = (ChildClass) _parentClass;
                Console.WriteLine(_childClass.y);
            }

            if (_parentClass is ChildClass childClass)
            {
                Console.WriteLine("Pattern Matching: " + childClass.y);
            }
        }        
    }
}
