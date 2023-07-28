using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace EternalResolve
{
    public class ClientSideConfig : ModConfig
    {
        public override ConfigScope Mode { get; } = ConfigScope.ClientSide;

        [DefaultValue( true )]
        [Label( "是否开启物品描述背景框 ? ( 即时生效 )" )]
        public bool mouseDrawItemTooltip;

    }
}
