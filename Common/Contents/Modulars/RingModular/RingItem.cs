using EternalResolve.Common.Contents.Modulars.ManaModular;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.RingModular
{
    public class RingItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public bool IsRing = false;

        public int ManaAdd = 0;

        public override void UpdateAccessory( Item item , Player player , bool hideVisual )
        {
            if ( item.GetGlobalItem<RingItem>( ).IsRing )
            {
                player.GetModPlayer<PlayerMana>( ).ManaMax +=
                    item.GetGlobalItem<RingItem>( ).ManaAdd;
            }
            base.UpdateAccessory( item , player , hideVisual );
        }
    }
}
