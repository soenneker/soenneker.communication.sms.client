using Azure.Communication.Sms;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Client.Abstract;

/// <summary>
/// Provides a lazily created, reusable Azure Communication Services SMS client.
/// </summary>
public interface ISmsClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Azure SMS client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel client initialization.</param>
    /// <returns>The configured Azure SMS client.</returns>
    ValueTask<SmsClient> Get(CancellationToken cancellationToken = default);
}
