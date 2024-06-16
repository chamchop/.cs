using Timer = System.Timers.Timer;
using static System.Console;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using Autofac;

namespace DesignPatterns.Mediator
{
    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker;
        }
    }

    public class Player : Actor
    {
        public string Name { get; set; }
        public int Score { get; set; } = 0;

        public Player(EventBroker broker, string name) : base(broker)
        {
            Name = name;
            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(ps => Console.WriteLine(ps.Name));
            broker.OfType<PlayerCardedEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(ps => Console.WriteLine(ps.Name));
        }

        public void Scored()
        {
            Score++;
            broker.Publish(new PlayerScoredEvent { Name = Name, GoalScored = Score });
        }
    }

    public class Coach : Actor
    {
        public Coach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>().Subscribe(pe =>
            {
                if (pe.GoalScored < 3) Console.WriteLine(pe.Name);
            });

            broker.OfType<PlayerCardedEvent>().Subscribe(pe =>
            {
                if (pe.Reason == "violence") Console.WriteLine(pe.Name);
            });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalScored { get; set; }
    }

    public class PlayerCardedEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }

    public class Exec
    {
        public static void Exe()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<Coach>();
            cb.Register((c, p) => new Player(c.Resolve<EventBroker>(), p.Named<string>("name")));
            using (var c = cb.Build())
            {
                var coach = c.Resolve<Coach>();
                var player = c.Resolve<Player>(new NamedParameter("name", "john"));
                player.Scored();
                player.Scored();
            }
        }
    }
}
