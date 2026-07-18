using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.Sync;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug).AddConsole());
ILogger logger = loggerFactory.CreateLogger<Gw2ApiGateway>();
var asuraGate = await AsuraGateService.CreateAsync(
    System.Environment.GetEnvironmentVariable("GW2_API_KEY") ?? string.Empty,
    "C:\\Users\\snaxx\\workspace\\AsuraGate.NET\\AsuraGate.Test\\dbs",
    "C:\\Users\\snaxx\\workspace\\AsuraGate.NET\\AsuraGate.Test\\dbs",
    Gw2ApiLocalization.English,
    Gw2ApiSchemaVersion.Latest,
    logger);

var items = await asuraGate.Api.Emote.GetAll();

foreach (var item in items)
{
    Console.WriteLine(item);
}