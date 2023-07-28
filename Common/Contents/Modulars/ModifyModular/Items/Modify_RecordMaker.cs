using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Items
{
    public class Modify_RecordMaker : GlobalItem
    {
        public string RecordName = "";

        public override void LoadData( Item item , TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                item.GetGlobalItem<Modify_RecordMaker>( ).RecordName = tag.GetString( "RecordMakerName" );
            }
            base.LoadData( item , tag );
        }
        public override void SaveData( Item item , TagCompound tag )
        {
            if ( Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                tag.Add( "RecordMakerName" , item.GetGlobalItem<Modify_RecordMaker>( ).RecordName );
            }
        }

        public override void OnCreate( Item item , ItemCreationContext context )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                item.GetGlobalItem<Modify_RecordMaker>( ).RecordName = Main.LocalPlayer.name;
            }
            base.OnCreate( item , context );
        }

        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }
    }
}
