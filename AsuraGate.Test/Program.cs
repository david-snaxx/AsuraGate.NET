using AsuraGate.Gateway;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.Sync;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = loggerFactory.CreateLogger<Gw2ApiGateway>();
await using var asuraGate = await AsuraGateService.CreateAsync(
    "33D87A53-5244-5342-B864-80279DC25775350E691B-B958-4D0E-9938-E8AE9C0D5EC6",
    "C:\\Users\\snaxx\\Desktop\\AsuraGate.NET\\AsuraGate.Test\\gw2cache.db",
    Gw2ApiLocalization.English,
    Gw2ApiSchemaVersion.Latest);
var request = asuraGate.Gw2ApiNavigator
    .Api
    .VersionTwo
    .Emote
    .GetAll();
var items = await asuraGate.Gw2ApiGateway.FetchAsync(request);

foreach (var item in items)
{
    Console.WriteLine(item);
}