using System;
using Utils;

public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
{
    private TAwaited _result;
    private bool _isCompleted;
    private Action _continuation;

    public TAwaited GetResult() => _result;
    public bool IsCompleted => _isCompleted;


    public void OnCompleted(Action continuation)
    {
        if (_isCompleted)
        {
            continuation?.Invoke();
        }
        else
        {
            _continuation = continuation;
        }
    }

    protected void ONWaitFinish(TAwaited result)
    {
        _result = result;
        _isCompleted = true;
        _continuation?.Invoke();
    }
}