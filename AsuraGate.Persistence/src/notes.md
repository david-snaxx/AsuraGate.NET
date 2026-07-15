The following model objects do not have an id:data document store. They do not have an obvious id field provided by 
the API. If these are added later, they will need auto incrementing ids.
Additionally, any with "not static" don't belong in the static caching strategy:
- Wvw/WvwTimer: not static, has no id
- Wvw/WvwMatchTeamGuildStats : not static
- Commerce/CommerceExchange: not static
- Commerce/CommerceDelivery: not static
- WizardsVault/WizardsVaultSeason: not static
- Pvp/PvpStats: not static
- Pvp/PvpStanding: not static
- Pvp/PvpLeaugeLeaderboardEntry: not static, needs to be grouped by leaderboard
- Account/AccountBuildStorageTemplate: not static
- Account/AccountLuck: not static, actually more like a map {id:luck, value:{luckvalue}
- Account/AccountMasteryPoints: not static
- Account/AccountWvw: not static
- Account.AccountAchievement: not static
<br> NOTE: All Guild objects need an attached guild id somehow if they are stored<br>
- Guild/GuildLogEntry: not static
- Guild/GuildTreasuryItem: not static, itemid=id
- Guild/GuildMember: not static, name=id
- Guild/GuildRank: not static, id=id where id is set by a guild
- Guild/GuildStashSection: not static, has no id
- Guild/GuildStorageItem: not static, id=itemid in the slot, row id should be different
- Achievement/AchievementDaily: not static, disabled currently?
<br> NOTE: ALl Characters objects need the character name associated with them even if its all in one shared multi
character table. Additionally, they are all not static. <br>
- Characters/CharacterTraining
- Characters/CharacterSpecializations
- Characters/CharacterSkills
- Characters/CharacterSab
- Characters/CharacterRecipes
- Characters/CharacterInventory
- Characters/CharacterEquipmentTab
- Characters/CharacterEquipment
- Characters/CharacterCrafting
- Characters/CharacterBuildTab
- Characters/CharacterBackstory