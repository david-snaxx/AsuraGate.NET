using AsuraGate.Gateway;
using AsuraGate.Persistence.Static.Meta;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.Spec.Requests.V2.Homestead;
using AsuraGate.Persistence.Static.Repositories.V2.Homestead;

namespace AsuraGate.Sync.Providers.V2.Homestead;

public class HomesteadGlyphProvider : Provider<HomesteadGlyph, string, HomesteadGlyphRepository, HomesteadGlyphRequest>
{
    public HomesteadGlyphProvider(HomesteadGlyphRepository repository, HomesteadGlyphRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
        : base(repository, request, gateway, staticMetaRepository, logger)
    {
    }
}
