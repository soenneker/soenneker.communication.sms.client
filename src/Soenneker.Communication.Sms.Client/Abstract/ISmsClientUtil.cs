using Azure.Communication.Sms;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the Azure Communication Services SMS client
/// </summary>
public interface ISmsClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured sms Client used by the sms client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested sms Client.</returns>
    ValueTask<SmsClient> Get(CancellationToken cancellationToken = default);
}
