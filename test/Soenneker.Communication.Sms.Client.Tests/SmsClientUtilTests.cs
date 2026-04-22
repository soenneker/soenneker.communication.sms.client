using Soenneker.Communication.Sms.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Communication.Sms.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class SmsClientUtilTests : HostedUnitTest
{
    private readonly ISmsClientUtil _util;

    public SmsClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<ISmsClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
