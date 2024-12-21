using Soenneker.Communication.Sms.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Communication.Sms.Client.Tests;

[Collection("Collection")]
public class SmsClientUtilTests : FixturedUnitTest
{
    private readonly ISmsClientUtil _util;

    public SmsClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ISmsClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
