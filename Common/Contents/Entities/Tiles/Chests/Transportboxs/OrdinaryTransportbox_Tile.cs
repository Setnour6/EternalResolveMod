using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Entities.Tiles.Chests.Transportboxs
{
    public class OrdinaryTransportbox_Tile : ModTileEntity
    {
        public override void LoadData( TagCompound tag )
        {

            base.LoadData( tag );
        }
        public override void SaveData( TagCompound tag )
        {

            base.SaveData( tag );
        }
        public override bool IsTileValidForEntity( int x , int y )
        {
            return false;
        }
    }
}
