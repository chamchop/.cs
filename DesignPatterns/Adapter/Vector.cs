namespace DesignPatterns.Adapter
{
    public interface IInteger
    {
        int Value { get; }
    }

    public static class Dimensions
    {

        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }

    public class Vector<T, D> where D : IInteger, new()
    {
        protected T[] data;

        public Vector()
        {
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];
            var providedSize = values.Length;
            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                data[i] = values[i];
        }

        public static Vector<T, D> Create(params T[] values)
        {
            return new Vector<T, D>(values);
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public T X
        {
            get => data[0];
            set => data[0] = value;
        }
    }

    public class VectorOfInt<D> : Vector<int, D> where D : IInteger, new()
    {
        public VectorOfInt()
        {

        }

        public VectorOfInt(params int[] values) : base(values)
        {

        }

        public static VectorOfInt<D> operator +(VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }

    public class VectorOfFloat<D> : Vector<float, D> where D : IInteger, new()
    {

    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i()
        {

        }

        public Vector2i(params int[] values) : base(values)
        {

        }
    }

    public class Vector3f : VectorOfFloat<Dimensions.Three>
    {
        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }

    class Exe
    {
        public static void Exec()
        {
            var v = new Vector2i(1, 2);
            v[0] = 0;

            var vv = new Vector2i(3, 4);

            var result = v + vv;

        }
    }
}
