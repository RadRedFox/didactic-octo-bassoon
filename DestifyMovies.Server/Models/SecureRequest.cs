namespace DestifyMovies.Server.Models;

public class SecureRequest<T>
{
    private static readonly string _key = "ShhhThisIsSecret";

    public string SecretKey { get; set; }
    public T Body { get; set; }

    public SecureRequest() { }

    public bool ValidateKey()
    {
        return SecretKey == _key;
    }
}
