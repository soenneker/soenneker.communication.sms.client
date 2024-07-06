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
public class SmsClientUtil: ISmsClientUtil
{
    private readonly AsyncSingleton<SmsClient> _client;

    public SmsClientUtil(ILogger<SmsClientUtil> logger, IConfiguration configuration)
    {
        _client = new AsyncSingleton<SmsClient>(() =>
        {
            logger.LogInformation("Connecting Azure Communication SMS Client...");

            var connectionString = configuration.GetValueStrict<string>("Azure:CommunicationServices:ConnectionString");

            var smsClient = new SmsClient(connectionString);
            
            return smsClient;
        });
    }

    public ValueTask<SmsClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _client.DisposeAsync();
    }
}
