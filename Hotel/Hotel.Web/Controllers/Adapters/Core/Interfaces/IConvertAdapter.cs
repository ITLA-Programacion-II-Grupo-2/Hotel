namespace Hotel.Web.Controllers.Adapters.Core.Interfaces
{
    public interface IConvertAdapter<TResult, TFrom>
    {
        TResult Convert(TFrom from);
    }
}
