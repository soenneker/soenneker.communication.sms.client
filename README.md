[![](https://img.shields.io/nuget/v/soenneker.communication.sms.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.communication.sms.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.client/actions/workflows/codeql.yml)

# Soenneker.Communication.Sms.Client

Provides a lazily created, reusable Azure Communication Services `SmsClient` through dependency injection.

## Installation

```bash
dotnet add package Soenneker.Communication.Sms.Client
```

## Configuration

```json
{
  "Azure": {
    "CommunicationServices": {
      "ConnectionString": "<Azure Communication Services connection string>"
    }
  }
}
```

Store the connection string in a secret provider rather than source control or a checked-in settings file.

## Registration

```csharp
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Communication.Sms.Client.Registrars;

services.AddSmsClientUtilAsSingleton();
```

`AddSmsClientUtilAsScoped()` creates one utility and Azure client per dependency-injection scope.

## Usage

```csharp
using Azure;
using Azure.Communication.Sms;
using Soenneker.Communication.Sms.Client.Abstract;

public sealed class SmsSender
{
    private readonly ISmsClientUtil _smsClients;

    public SmsSender(ISmsClientUtil smsClients)
    {
        _smsClients = smsClients;
    }

    public async ValueTask<SmsSendResult> Send(
        string from,
        string to,
        string message,
        CancellationToken cancellationToken)
    {
        SmsClient client = await _smsClients.Get(cancellationToken);

        Response<SmsSendResult> response = await client.SendAsync(
            from,
            to,
            message,
            cancellationToken: cancellationToken);

        return response.Value;
    }
}
```

The `from` number must belong to the authenticated Azure Communication Services resource. Use E.164 phone-number formatting where required by Azure and the destination country.

Inspect `SmsSendResult.Successful`, `ErrorMessage`, and related result fields; an accepted HTTP request does not make downstream carrier delivery instantaneous or guaranteed.

## Lifecycle and behavior

- The first `Get` creates the Azure client from `Azure:CommunicationServices:ConnectionString`; later calls return the same client.
- The token passed to `Get` applies to lazy initialization. Pass a token to every `SmsClient` operation as well.
- Azure SDK clients are designed for reuse. Let dependency injection dispose `ISmsClientUtil`; do not construct a new client per message.
- Azure service failures are thrown as `RequestFailedException`.
- This package exposes the Azure SDK client directly. Use `Soenneker.Communication.Sms.Util` for the repository's higher-level SMS sending abstraction.
- Avoid logging message bodies, recipient numbers, connection strings, or other communication data unless the application has an explicit redaction and retention policy.
