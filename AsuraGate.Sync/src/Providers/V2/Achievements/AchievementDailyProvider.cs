using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.V2.Achievements;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.StaticCache.Repositories.V2.Achievements;

namespace AsuraGate.Sync.Providers.V2.Achievements;

public class AchievementDailyProvider
{
    private readonly AchievementDailyRepository _repository;
    private readonly AchievementDailyRequest _request;
    private readonly Gw2ApiGateway _gateway;

    public AchievementDailyProvider(AchievementDailyRepository repository, AchievementDailyRequest request, Gw2ApiGateway gateway)
    {
        _repository = repository;
        _request = request;
        _gateway = gateway;
    }

    public async Task<AchievementDaily?> GetAsync()
    {
        AchievementDaily? cached = await _repository.GetAsync();
        if (cached is not null) return cached;

        IExecutableGw2ApiRequest<AchievementDaily, object> request = _request.GetObject<AchievementDaily, object>();
        AchievementDaily? fetched = await _gateway.FetchAsync(request);
        if (fetched is null) return null;

        await _repository.UpsertAsync(fetched);
        return fetched;
    }
}
