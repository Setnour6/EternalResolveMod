using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Npcs
{
    public abstract class ERNpc : ModNPC
    {
        public GameCulture Chinese = GameCulture.FromCultureName( GameCulture.CultureName.Chinese );

        public GameCulture English = GameCulture.FromCultureName( GameCulture.CultureName.English );
    }
}
