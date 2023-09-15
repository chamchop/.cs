using static DesignPatterns.Decorator.DynamicComposition;

namespace DesignPatterns.Decorator
{
    public class DecoratorCycles
    {
        public abstract class ShapeDecoratorCyclePolicy
        {
            public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
            public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);
        }

        public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
        {
            private bool Handler(Type type, IList<Type> allTypes)
            {
                if (allTypes.Contains(type))
                {
                    throw new InvalidOperationException
                        ($"cycle detected, type is {type.FullName}");
                }
                return true;
            }

            public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
            {
                return Handler(type, allTypes);
            }

            public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
            {
                return Handler(type, allTypes);
            }
        }

        public class CyclesAllowedPolicy : ShapeDecoratorCyclePolicy
        {
            public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
            {
                return true;
            }

            public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
            {
                return true;
            }
        }

        public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
        {
            public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
            {
                return true;
            }

            public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
            {
                return !allTypes.Contains(type);
            }

        }

        public static void Print()
        {
            var circle = new Circle(2);
            var colouredRed = new ColouredShape(circle, "red");
            var colouredBlue = new ColouredShape(circle, "blue");
            Console.Write(colouredRed.AsString());

        }
    }
}
