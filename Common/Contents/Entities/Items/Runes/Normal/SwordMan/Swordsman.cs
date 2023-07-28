using EternalResolve.Common.Contents.Modulars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes.Normal.SwordMan
{
    public class Swordsman : CompleteSet
    {
        public override bool Check( )
        {
            List<int> types = new List<int>( );
            for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length ; count++ )
            {
                types.Add( Modular.RuneInterface.WeaponRune.Slot[count].Item.type );
            }
            if ( types.Contains( ModContent.ItemType<Sharp>( ) ) && types.Contains( ModContent.ItemType<Defenser>( ) ) )
            {
                return true;
            }
            else
                return false;
        }
        public override string Text( )
        {
            return "剑士[2] :\n" +
                      "    获得12%近战速度加成.";
        }
        public override void UpdateInventory( Player player )
        {
            player.meleeSpeed += 0.12f;
            base.UpdateInventory( player );
        }
    }
}
