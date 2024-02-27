using Azure.Communication.Sms;
using System;
using System.Threading.Tasks;

namespace Soenneker.Communication.Sms.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the Azure Communication Services SMS client
/// </summary>
public interface ISmsClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<SmsClient> Get();
}
