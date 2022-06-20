using System;
using UniRx;
using UserControlSystem;

public abstract class StatefulScriptableObjectValueBase<T> : ScriptableObjectValueBase<T>, IObservable<T>
{
    private ReactiveProperty<T> _innerDataSource = new ReactiveProperty<T>();
    public void SetValue(T value)
    {
        base.SetValue(value);
        _innerDataSource.Value = value;
    }
    public IDisposable Subscribe(IObserver<T> observer) => _innerDataSource.Subscribe(observer);
}