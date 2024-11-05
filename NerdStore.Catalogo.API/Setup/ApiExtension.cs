namespace NerdStore.Catalogo.API.Setup;

public static class ApiExtension
{
    public static void RegisterApi(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        
    }

}