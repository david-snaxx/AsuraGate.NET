using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.Sync;

AsuraGateService asuraGate = new AsuraGateService(
    "33D87A53-5244-5342-B864-80279DC25775350E691B-B958-4D0E-9938-E8AE9C0D5EC6",
    "C:\\Users\\snaxx\\Desktop\\AsuraGate.NET\\AsuraGate.Test\\gw2cache.db",
    Gw2ApiLocalization.English,
    Gw2ApiSchemaVersion.Latest);

var items = await asuraGate.Gw2ApiGateway.FetchAsync(
    Gw2ApiNavigator.Api.VersionTwo.Emote.GetAll());

foreach (var item in items)
{
    Console.WriteLine(item);
}