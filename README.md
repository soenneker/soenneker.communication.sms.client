[![](https://img.shields.io/nuget/v/soenneker.communication.sms.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.communication.sms.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.communication.sms.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.communication.sms.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.communication.sms.client/actions/workflows/codeql.yml)

# Soenneker.Communication.Sms.Client

An async thread-safe singleton for the Azure Communication Services SMS client.

## Install

```bash
dotnet add package Soenneker.Communication.Sms.Client
```

## Quick start

```csharp
using Soenneker.Communication.Sms.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddSmsClientUtilAsSingleton();
```

Adds `ISmsClientUtil` as a singleton service.

## What you get

- `ISmsClientUtil` — An async thread-safe singleton for the Azure Communication Services SMS client.
- `SmsClientUtilRegistrar` — An async thread-safe singleton for the Azure Communication Services SMS client.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `SmsClientUtilRegistrar.AddSmsClientUtilAsSingleton(services)` | Adds `ISmsClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `SmsClientUtilRegistrar.AddSmsClientUtilAsScoped(services)` | Adds `ISmsClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
