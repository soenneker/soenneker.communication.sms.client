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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SmsClient> Get(CancellationToken cancellationToken = default);
}
