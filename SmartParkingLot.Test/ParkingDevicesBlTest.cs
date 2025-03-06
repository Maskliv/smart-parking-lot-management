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
public class ParkingDevicesBlTest
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
    public async Task GetAllParkingDevicesTest()
    {

        var repo = new MockDeviceRepository(_context);
        var bl = new ParkingDevicesBL(repo);

        var offset = Tuple.Create(1, 20);
        var result = await bl.Get(offset);

        var listResults = result.ToList();
        Assert.That(listResults, Has.Count.EqualTo(5));
        Assert.That(listResults[2].DeviceId, Is.EqualTo(Guid.Parse("4d066444-c081-4199-b2e9-9bf694b2835e")));

        Assert.That(listResults[4].DeviceId, Is.EqualTo(Guid.Parse("e3dbf447-569c-4200-afec-fc99eabbcab2")));
    }

    [Test]
    public async Task AddParkingDeviceTest()
    {

        var repo = new MockDeviceRepository(_context);
        var bl = new ParkingDevicesBL(repo);

        var newDevice = new DeviceDto
        {
            DeviceId = new Guid("6e95bdf1-f661-4a60-9b23-ac6862b2b769")
        };
        var created = await bl.AddDevice(newDevice);

        var queried = await bl.GetById(created.DeviceId);

        Assert.That(created, Is.Not.Null);
        Assert.That(created.DeviceId, Is.EqualTo(queried.DeviceId));

    }

   



    [TearDown]
    public void TearDown()
    {
        _context.Database.CloseConnection();
        _context.Dispose();
        
    }
}