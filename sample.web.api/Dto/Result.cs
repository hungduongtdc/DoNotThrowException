
using System.Diagnostics.Contracts;

public enum EState
{
    Success, Fail
}
public class Result<T>
{
    private EState State;
    private Exception Ex;
    public T Value { get; private set; }
    public Result()
    {

    }
    public Result(Exception ex)
    {
        this.State = EState.Fail;
        this.Ex = ex;
    }


    public R Match<R>(Func<T, R> success, Func<Exception, R> fail)
    {
        if (State == EState.Success)
        {
            return success(Value);
        }
        return fail(Ex);
    }

    [Pure]
    public static implicit operator Result<T>(T obj) => new Result<T>() { Value = obj };
}