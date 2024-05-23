
using DataAccesslayer;

public class Starter
{

    public static void Main(string[] args)
    {
        ProductServices proser = new ProductServices();
        proser.Insert();
    }
}
