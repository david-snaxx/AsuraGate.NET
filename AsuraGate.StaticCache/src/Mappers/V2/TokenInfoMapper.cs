using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class TokenInfoMapper
{
    public static TokenInfoEntity ToTokenInfoEntity(TokenInfo tokenInfo) => new TokenInfoEntity()
    {
        Id = tokenInfo.Id,
        Name = tokenInfo.Name,
        Type = tokenInfo.Type,
        ExpiresAt = tokenInfo.ExpiresAt,
        IssuedAt = tokenInfo.IssuedAt
    };

    public static IEnumerable<TokenInfoPermissionEntity> ToPermissionEntities(TokenInfo tokenInfo) =>
        tokenInfo.Permissions.Select(permission => new TokenInfoPermissionEntity()
        {
            TokenInfoId = tokenInfo.Id,
            Permission = permission
        });

    public static IEnumerable<TokenInfoUrlEntity> ToUrlEntities(TokenInfo tokenInfo) =>
        tokenInfo.Urls.Select(url => new TokenInfoUrlEntity()
        {
            TokenInfoId = tokenInfo.Id,
            Url = url
        });

    public static TokenInfo ToModel(
        TokenInfoEntity entity,
        IEnumerable<TokenInfoPermissionEntity> permissionEntities,
        IEnumerable<TokenInfoUrlEntity> urlEntities) => new TokenInfo()
    {
        Id = entity.Id,
        Name = entity.Name,
        Type = entity.Type,
        ExpiresAt = entity.ExpiresAt,
        IssuedAt = entity.IssuedAt,
        Permissions = permissionEntities.Select(permission => permission.Permission).ToArray(),
        Urls = urlEntities.Select(url => url.Url).ToArray()
    };
}
