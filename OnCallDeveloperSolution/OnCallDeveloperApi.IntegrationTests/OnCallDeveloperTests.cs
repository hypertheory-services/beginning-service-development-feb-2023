
using Alba;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using OnCallDeveloperApi.Adapters;
using OnCallDeveloperApi.Models;

namespace OnCallDeveloperApi.IntegrationTests;

public class OnCallDeveloperTests
{
    [Fact]
    public async Task GettingOnCallDeveloperDuringBusinessHours()
    {
        // "Scenario" - 
        // We make a GET request to /oncalldeveloper
        // AND it is during business hours
        // We should get a 200Ok
        // And we should get back Bob's information.

        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var fakeTimeToReturn = new DateTimeOffset(1969, 4, 20, 16, 59, 59, TimeSpan.FromHours(-5));
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(x => x.GetCurrent()).Returns(fakeTimeToReturn);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedClock.Object);
            });

        });
        var responseMessage =  await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });

        var response = responseMessage.ReadAsJson<OnCallDeveloperResponse>();
        Assert.NotNull(response);
        Assert.Equal("Bob", response.Contact.FirstName);
        // etc. etc. right phone number? right email? etc.

    }

    [Fact]
    public async Task GettingOnCallDeveloperAfterBusinessHours()
    {
        await using var host = await AlbaHost.For<Program>(builder =>
        {
            var fakeTimeToReturn = new DateTimeOffset(1969, 4, 20, 17, 00, 00, TimeSpan.FromHours(-5));
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(x => x.GetCurrent()).Returns(fakeTimeToReturn);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<ISystemTime>(stubbedClock.Object);
            });

        });

        var responseMessage = await host.Scenario(api =>
        {
            api.Get.Url("/oncalldeveloper");
            api.StatusCodeShouldBeOk();
        });

        var response = responseMessage.ReadAsJson<OnCallServiceResponse>();
        Assert.NotNull(response);
        Assert.Equal("Our Help Service", response.Contact.Name);
        // etc. etc. right phone number? right email? etc.
    }
}
