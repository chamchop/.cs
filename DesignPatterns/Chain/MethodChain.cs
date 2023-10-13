namespace DesignPatterns.Chain
{
    public class MethodChain
    {
        public class Creature
        {
            public string Name;
            public int Attack, Defense;

            public Creature(string name, int attack, int defense)
            {
                Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
                Attack = attack;
                Defense = defense;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class CreatureModifier
        {
            protected Creature creature;
            protected CreatureModifier next;

            public CreatureModifier(Creature creature)
            {
                this.creature = creature ?? throw new ArgumentNullException(paramName: nameof(creature));
            }

            public void Add(CreatureModifier cm)
            {
                if (next != null)
                {
                    next.Add(cm);
                }
                else next = cm;
            }

            public virtual void Handle() => next?.Handle();
        }

        public class DoubleAttackModifier : CreatureModifier
        {
            public DoubleAttackModifier(Creature creature) : base(creature)
            {

            }

            public override void Handle()
            {
                Console.WriteLine("double attack");
                creature.Attack *= 2;
                base.Handle();
            }
        }

        public class IncreasedDefenseModifier : CreatureModifier
        {
            public IncreasedDefenseModifier(Creature creature) : base(creature)
            {                
            }

            public override void Handle()
            {
                Console.WriteLine("increase defense");
                creature.Defense += 3;
                base.Handle();
            }
        }

        public class NoBusesModifier : CreatureModifier
        {
            public NoBusesModifier(Creature creature) : base(creature)
            {
                
            }

            public override void Handle()
            {
                Console.WriteLine("none");
            }
        }

        public static void Print()
        {
            var goblin = new Creature("goblin", 2, 2);
            Console.WriteLine(goblin);
            var root = new CreatureModifier(goblin);

            root.Add(new DoubleAttackModifier(goblin));
            root.Add(new IncreasedDefenseModifier(goblin));
            root.Handle();
            Console.WriteLine(goblin);
        }
    }
}
