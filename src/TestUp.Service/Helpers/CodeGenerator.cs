namespace TestUp.Service.Helpers;

public class CodeGenerator
{
    public static int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(100000, 999999);
    }
}