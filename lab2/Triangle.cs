using Lab2.Library;

namespace Lab2.Library
{
    public class Triangle<T> : Figure<T>, IDisposable where T : INumber<T>
    {
        readonly T _a;
        readonly T _b;
        readonly T _c;
        public Triangle(T a, T b, T c) : base(nameof(Triangle<T>), FigureType.Figure2D)
        {
            if (a <= T.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }
            if (b <= T.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }
            if (c <= T.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(c));
            }
            _a = a;
            _b = b;
            _c = c;
        }
        public void Deconstruct(out T a, out T b, out T c)
        {
            a = _a;
            b = _b;
            c = _c;
        }
        public override T CalculatePerimeter()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            return _a + _b + _c;
        }
        public override T CalculateSquare()
        {
            OnCalculateSquareEvent(EventArgs.Empty);
            T _p = (_a + _b + _c) * T.CreateChecked(0.5);
            return (T)Convert.ChangeType(Math.Round(Math.Sqrt(Convert.ToDouble(_p * (_p - _a) * (_p - _b) * (_p - _c))), 3), typeof(T));
        }
        public override T CalculateVolume()
        {
            OnCalculateVolumeEvent(EventArgs.Empty);
            throw new ArgumentOutOfRangeException();
        }
        public override async Task<T> CalculatePerimeterAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculatePerimeter();
            if (OnCalculatePerimeterAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override async Task<T> CalculateSquareAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculateSquare();
            if (OnCalculateSquareAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override async Task<T> CalculateVolumeAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            T result = CalculateVolume();
            if (OnCalculateVolumeAsyncEvent(EventArgs.Empty) is Task @event)
            {
                await @event;
            }
            return result;
        }
        public override void Save()
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Стороны треугольника равны: {_a}, {_b}, {_c}, значит периметр равен: {CalculatePerimeter()}, площадь равна: {CalculateSquare()}, двумерная фигура не имеет объема!";
            writer.Write(str);
            writer.Flush();
        }
        public override async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Стороны треугольника равны: {_a}, {_b}, {_c}, значит периметр равен: {CalculatePerimeter()}, Площадь равна: {CalculateSquare()}, Двумерная фигура не может иметь объема!";
            await writer.WriteAsync(str);
            await writer.FlushAsync();
        }
    }
}
