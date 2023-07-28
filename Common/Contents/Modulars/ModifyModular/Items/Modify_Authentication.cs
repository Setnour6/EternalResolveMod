using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Items
{
    public class Modify_Authentication : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public bool Authentication = false;

        public override void LoadData( Item item , TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                item.GetGlobalItem<Modify_Authentication>( ).Authentication = tag.GetBool( "EternalResolve:ItemAuthentication" );
            }
            base.LoadData( item , tag );
        }
        public override void SaveData( Item item , TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                tag.Add( "EternalResolve:ItemAuthentication" , item.GetGlobalItem<Modify_Authentication>( ).Authentication );
            }
        }
    }
}
