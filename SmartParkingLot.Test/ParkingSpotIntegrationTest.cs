using SmartParkingLot.Api.Domain.Enums;
using SmartParkingLot.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartParkingLot.Test;

[TestFixture]
public class ParkingSpotIntegrationTest
{
    private HttpClient _client;
    private TestWebFactory _factory;

    private const string REST_ENDPOINT = "api/parking-spots";

    [SetUp]
    public void Setup()
    {
        _factory = new TestWebFactory();
        _client = _factory.CreateClient();
    }

    [Test]
    public async Task RegisteredDeviceCanChangeSpotStatusTest()
    {
        var spotId = 7L;

        var customRequest = new HttpRequestMessage(HttpMethod.Post, REST_ENDPOINT + $"/{spotId}/{SpotStatus.Free}");
        customRequest.Headers.Add("Device-Id", "2c6e8dd4-64f9-41aa-b63b-6eb0f254dcb4");

        var response = await _client.SendAsync(customRequest);

        var result = await response.Content.ReadAsStringAsync();
        
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        Assert.That(result, Is.Empty);
    }

    [Test]
    public async Task NotRegisteredDeviceCannotChangeSpotStatusTest()
    {
        var spotId = 7L;

        var customRequest = new HttpRequestMessage(HttpMethod.Post, REST_ENDPOINT + $"/{spotId}/{SpotStatus.Free}");
        customRequest.Headers.Add("Device-Id", "93af6d71-46dc-4cb2-95a2-0fad2f38a376"); //Some other GUID

        var response = await _client.SendAsync(customRequest);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
