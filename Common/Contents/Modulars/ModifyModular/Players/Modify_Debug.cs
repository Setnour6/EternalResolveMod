using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Players
{
    public class Modify_Debug : ModPlayer
    {
        protected override bool CloneNewInstances => true;
        public override void PostUpdate( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( Main.LocalPlayer.HeldItem.stack == 0 )
                    Main.placementPreview = false;
                else if ( Main.LocalPlayer.HeldItem.createTile > -1 && Main.LocalPlayer.HeldItem.stack > 0 )
                    Main.placementPreview = true;
            }
            base.PostUpdate( );
        }
        public override bool CanUseItem( Item item )
        {
            return Main.LocalPlayer.HeldItem.type != ItemID.None;
        }
    }
}
