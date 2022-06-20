using System;
using UniRx;
using UserControlSystem;

namespace Utils
{
    public abstract class StatelessScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
    {
        private Subject<T> _innerDataSource = new Subject<T>();
        public void SetValue(T value)
        {
            base.SetValue(value);
            _innerDataSource.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<T> observer) => _innerDataSource.Subscribe(observer);
    }
}