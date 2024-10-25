namespace Vroom.Shareable.Exceptions;

public class DomainException : Exception
{
    public string Mensagem { get; }

    public DomainException(string mensagem) : base(mensagem)
    {
        Mensagem = mensagem;
    }
}