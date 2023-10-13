namespace DesignPatterns.Proxy
{
    internal class CompositeProxy
    {
        public class Creature
        {
            public byte Age;
            public int X, Y;
        }

        public class Creatures
        {
            private readonly int size;
            private byte[] age;
            private int[] x, y;

            public Creatures(int size)
            {
                this.size = size;
                age = new byte[size];
                x = new int[size];
                y = new int[size];
            }

            public struct CreatureProxy
            {

                private readonly Creatures creatures;
                private readonly int index;

                public CreatureProxy(Creatures creatures, int index)
                {
                    this.creatures = creatures;
                    this.index = index;
                }

                public ref byte Age => ref creatures.age[index];
                public ref byte X => ref creatures.age[index];
                public ref byte Y => ref creatures.age[index];
            }

            public IEnumerator<CreatureProxy> GetEnumerator()
            {
                for (int pos = 0; pos < size; ++pos)
                {
                    yield return new CreatureProxy(this, pos);
                }
            }
        }

        public class ArrayBackedProperties
        {
            public bool? All
            {
                get
                {
                    if (flags.Skip(1).All(f => f == flags[0])) return flags[0];
                    return null;
                }
                set
                {
                    if (!value.HasValue) return;
                    for (int i = 0; i < flags.Length; i++)
                    {
                        flags[i] = value.Value;
                    }
                }
            }

            private bool[] flags = new bool[3];
            public bool Pillars
            {
                get => flags[0];
                set => flags[0] = value;
            }

            public bool Walls
            {
                get => flags[1];
                set => flags[1] = value;
            }

            public bool Floors
            {
                get => flags[2];
                set => flags[2] = value;
            }

        }

        public static void Print()
        {
            var creatures = new Creature[100];
            foreach (var creature in creatures)
            {
                creature.X++;
            }

            var creatureTwo = new Creatures(100);
            foreach (Creatures.CreatureProxy creature in creatureTwo)
            {
                creature.X++;
            }
        }
    }
}
