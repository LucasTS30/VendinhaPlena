namespace Core.Exceptions;

public class DividaEmAbertoException : Exception
{
    public DividaEmAbertoException(string? message = "Uma nova dívida não pode ser criada, pois o cliente já possui dívida em aberto.") : base(message)
    {}
}