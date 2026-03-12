using Azure.Communication.Sms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Communication.Sms.Client.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Utils.AsyncSingleton;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Client;

/// <inheritdoc cref="ISmsClientUtil"/>
public sealed class SmsClientUtil: ISmsClientUtil
{
    private readonly AsyncSingleton<SmsClient> _client;
    private readonly ILogger<SmsClientUtil> _logger;
    private readonly IConfiguration _configuration;

    public SmsClientUtil(ILogger<SmsClientUtil> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _client = new AsyncSingleton<SmsClient>(CreateClient);
    }

    private SmsClient CreateClient()
    {
        _logger.LogInformation("Connecting Azure Communication SMS Client...");

        var connectionString = _configuration.GetValueStrict<string>("Azure:CommunicationServices:ConnectionString");

        return new SmsClient(connectionString);
    }

    public ValueTask<SmsClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
