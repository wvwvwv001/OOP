using Lab2.Library;

namespace Lab2.Library
{
    public class Cone<T> : Figure<T> where T : INumber<T>
    {
        private T _r;
        private T _h;
        public Cone(T r, T h) : base(nameof(Cone<T>), FigureType.Figure3D)
        {
            if (r <= T.Zero)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (h <= T.Zero)
            {
                throw new ArgumentOutOfRangeException();
            }
            _r = r;
            _h = h;
        }
        public void Deconstruct(out T r, out T h)
        {
            r = _r;
            h = _h;
        }
        public override T CalculatePerimeter()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            return T.CreateChecked(double.Round(double.CreateChecked(T.CreateChecked(double.Pi) * T.CreateChecked(2) * _r), 3, MidpointRounding.ToZero));
        }
        public override T CalculateSquare()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            T _l = (T)Convert.ChangeType(Math.Round(Math.Sqrt(Convert.ToDouble((_r * _r) + (_h * _h))), 3), typeof(T));
            return (T.CreateChecked(Math.Round(Math.PI, 20)) * _r * _l) + (T.CreateChecked(Math.Round(Math.PI, 20)) * (_r * _r));
        }
        public override T CalculateVolume()
        {
            OnCalculatePerimeterEvent(EventArgs.Empty);
            T res = T.CreateChecked(double.Pi) * (_r * _r) * _h * T.CreateChecked(1.0 / 3);
            return T.CreateChecked(Math.Round(double.CreateChecked(res), 3, MidpointRounding.ToZero));
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
            string str = @$"Радиус равен {_r}, высота равна {_h}, значит объем конуса равен {CalculateVolume()}";
            writer.Write(str);
            writer.Flush();
        }
        public override async Task SaveAsync(CancellationToken cancellationToken = default)
        {
            using StreamWriter writer = new StreamWriter(FileStream, leaveOpen: true);
            string str = @$"Радиус равен {_r}, высота равна {_h}, значит объем конуса равен {CalculateVolume()}";
            await writer.WriteAsync(str);
            await writer.FlushAsync();
        }
    }
}
