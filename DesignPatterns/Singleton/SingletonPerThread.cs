namespace DesignPatterns.Singleton
{
    public sealed class SingletonPerThread
    {
        private static ThreadLocal<SingletonPerThread> threadInstance = new ThreadLocal<SingletonPerThread>(() => new SingletonPerThread());
        public static SingletonPerThread Instance = threadInstance.Value;
        public int Id;

        public SingletonPerThread()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }

        public static void Exe()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("t1: " + SingletonPerThread.Instance.Id);
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("t2: " + SingletonPerThread.Instance.Id);
                Console.WriteLine("t2: " + SingletonPerThread.Instance.Id);
            });

            Task.WaitAll(t1, t2);
        }

    }
}
