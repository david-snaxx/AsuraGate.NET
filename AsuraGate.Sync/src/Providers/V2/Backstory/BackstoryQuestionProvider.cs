using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Backstory;
using AsuraGate.Spec.Requests.V2.Backstory;
using AsuraGate.Persistence.Static.Repositories.V2.Backstory;

namespace AsuraGate.Sync.Providers.V2.Backstory;

public class BackstoryQuestionProvider : Provider<BackstoryQuestion, int, BackstoryQuestionRepository, BackstoryQuestionRequest>
{
    public BackstoryQuestionProvider(BackstoryQuestionRepository repository, BackstoryQuestionRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
