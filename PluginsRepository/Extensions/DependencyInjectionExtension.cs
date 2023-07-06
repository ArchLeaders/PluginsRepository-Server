namespace PluginsRepository.Extensions;

public static class DependencyInjectionExtension
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddMemoryCache();

        builder.Services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
        builder.Services.AddSingleton(typeof(IDataProvider<>), typeof(MongoDataProvider<>));

        return builder;
    }
}
