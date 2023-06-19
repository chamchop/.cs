using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Structures
{
    internal class Printing
    {
        public static void Print()
        {
            Category category = new Category();
            category.CategoryId = 20;
            category.CategoryName = "General";
            Console.WriteLine(category.CategoryId);
            Console.WriteLine(category.CategoryName);
            Console.WriteLine(category.GetCategoryNameLength());

            Category categoryII = new Category(5, "Major");
            Console.WriteLine(categoryII.CategoryId);
            Console.WriteLine(categoryII.CategoryName);
            Console.WriteLine(categoryII.GetCategoryNameLength());

            Struct structure; // stack, instance, value type
            structure.x = 1;
            structure.y = 2;
            Console.WriteLine(structure.x);
            Console.WriteLine(structure.y);
            Struct structureII = new Struct();
            structure = structureII; // new struct instance
            structureII.x = 10;
            structureII.y = 20;
            Console.WriteLine(structureII.x);
            Console.WriteLine(structureII.y);
            structure.x = 1;
            structure.y = 2;
            Console.WriteLine(structure.x);
            Console.WriteLine(structure.y);
            Console.WriteLine(structureII.x);
            Console.WriteLine(structureII.y);
            Class classes = new Class(); // heap, reference type
            classes.x = 1;
            classes.y = 2;
            Console.WriteLine(classes.x);
            Console.WriteLine(classes.y);
            Class classesII = new Class();
            classesII = classes; // references same object
            classesII.x = 10;
            classesII.y = 20;
            Console.WriteLine(classesII.x);
            Console.WriteLine(classesII.y);
            classes.x = 3; // overwrites previous declaration
            classes.y = 4; // overwrites previous declaration
            Console.WriteLine(classes.x);
            Console.WriteLine(classes.y);
            Console.WriteLine(classesII.x);
            Console.WriteLine(classesII.y);

            Marvel character = new Marvel("Thanos");
            Console.WriteLine(character.CharacterName);
            character.PrintCharacterName();

            // OBJECTS
            int x = 10;
            object obj = x; // boxing, stack to heap, value type to reference type
            Console.WriteLine(obj);

            object objs = 10;
            int y = (int)objs; // unboxing, heap to stack, reference type to value type
            Console.WriteLine(y);

            System.Object obje = new Category() { CategoryId = 1, CategoryName = "test" };
            Console.WriteLine(obje.Equals(new Category()
            {
                CategoryId = 1,
                CategoryName = "test"
            }));
            Console.WriteLine(obje.GetHashCode());
            Console.WriteLine(obje.ToString());
            Console.WriteLine(obje.GetType().ToString());

        }
    }
}
