namespace SmartParkingLot.Test;

using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SmartParkingLot.Api.BL;
using SmartParkingLot.Api.Domain.Dto;
using SmartParkingLot.Api.Domain.Enums;
using SmartParkingLot.Api.Domain.Exceptions;
using SmartParkingLot.Test.Mocks;
using SmartParkingLot.Test.Mocks.EF;
using System.Threading.Tasks;

[TestFixture]
public class ParkingSpotBlTest
{
    private MockAppDbContext _context;

    [OneTimeSetUp]
    public void Init()
    {
        SQLitePCL.Batteries.Init();
    }

    [SetUp]
    public void Setup()
    {
        _context = new MockAppDbContext();
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();

    }

    [Test]
    public async Task GetAllParkingSpotsTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var offset = Tuple.Create(1, 20);
        var result = await bl.Get(offset);

        var listResults = result.ToList();
        Assert.That(listResults, Has.Count.EqualTo(5));
        Assert.That(listResults[2].SpotId, Is.EqualTo(4));
        Assert.That(listResults[2].Status, Is.EqualTo(SpotStatus.Free));

        Assert.That(listResults[4].SpotId, Is.EqualTo(7));
        Assert.That(listResults[4].Status, Is.EqualTo(SpotStatus.Occupied));
    }

    [Test]
    public async Task AddParkingSpotTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var newSpot = new SpotDto
        {
            Zone = "Z",
            PositionId = "Z-45",
            Status = SpotStatus.Free,
        };
        var created = await bl.AddSpot(newSpot);

        var queried = await bl.GetById(created.SpotId);

        Assert.That(created, Is.Not.Null);
        Assert.That(created.SpotId, Is.EqualTo(queried.SpotId));
        Assert.That(created.Zone, Is.EqualTo(queried.Zone));
        Assert.That(created.PositionId, Is.EqualTo(queried.PositionId));
        Assert.That(created.Status, Is.EqualTo(queried.Status));

    }

    [Test]
    public async Task UpdateStatusParkingSpotTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var spotId = 4L;
        await bl.UpdateSpotStatus(spotId, "occupied");

        var queried = await bl.GetById(spotId);

        Assert.That(queried, Is.Not.Null);
        Assert.That(queried.SpotId, Is.EqualTo(spotId));
        Assert.That(queried.Status, Is.EqualTo(SpotStatus.Occupied));

        
        

    }

    [Test]
    public void UpdateStatusParkingSpotTwiceThrowsErrorTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var spotId = 7L;
        Assert.ThrowsAsync<BadRequestException>(async () => await bl.UpdateSpotStatus(spotId, "occupied"));

        spotId = 6L;
        Assert.ThrowsAsync<BadRequestException>(async () => await bl.UpdateSpotStatus(spotId, "free"));

    }

    [Test]
    public void UpdateStatusParkingSpotNotExistTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var spotId = 10L;
        Assert.ThrowsAsync<NotFoundException>(async () => await bl.UpdateSpotStatus(spotId, "occupied"));

    }

    [Test]
    public async Task DeleteParkingSpotTest()
    {

        var repo = new MockSpotRepository(_context);
        var bl = new ParkingSpotsBL(repo);

        var spotId = 5L;
        await bl.DeleteSpot(spotId);


        Assert.ThrowsAsync<NotFoundException>(async () => await bl.GetById(spotId));

    }



    [TearDown]
    public void TearDown()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
        
    }
}