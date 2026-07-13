using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.Spec.Requests.V2.Backstory;
using AsuraGate.StaticCache.Repositories.V2.Backstory;

namespace AsuraGate.Sync.Providers.V2.Backstory;

public class BackstoryQuestionProvider : Provider<BackstoryQuestion, int, BackstoryQuestionRepository, BackstoryQuestionRequest>
{
    public BackstoryQuestionProvider(BackstoryQuestionRepository repository, BackstoryQuestionRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
