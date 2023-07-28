using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Items
{
    public class Modify_Autoreuse : GlobalItem
    {
        public override void SetDefaults( Item item )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                item.autoReuse = true;
                if ( item.type == ItemID.CopperPickaxe )
                {
                    item.useTime -= 4;
                    item.useAnimation -= 4;
                }
            }
            base.SetDefaults( item );
        }
    }
}
