using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendMail;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddScoped<MailService>();
        services.AddScoped<HttpClientService>();
        services.AddScoped<CfgMailService>();
    })
    .Build();

ExemplifyServiceLifetime(host.Services);

async void ExemplifyServiceLifetime(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    MailService _mailServcie = provider.GetRequiredService<MailService>();

    // Replace real data here
    var obj = new MailRequestDto();

    await _mailServcie.SendMailAsync(obj);
}

await host.RunAsync();