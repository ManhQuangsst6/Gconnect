namespace Gconnect.Application.Common.Models;
public class BaseViewModel <T>
{
    public bool IsError { get; set; }
    public string ErrorMessage { get; set; }
    public T Result { get; set; }
}
