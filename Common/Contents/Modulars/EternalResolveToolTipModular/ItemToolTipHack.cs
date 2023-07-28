using EternalResolve.Common.Graphics.Replaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.ObjectModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class ItemToolTipHack : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public Texture2D BackGround { get; set; }

        public ItemModToolTip ToolTip;

        public TextLine TextLine;

        public override void SetDefaults( Item item )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                if ( TextLine == null )
                    TextLine = new TextLine( "" , Color.White );
                ToolTip = new ItemModToolTip( );
                item.GetGlobalItem<ItemToolTipHack>( ).BackGround = ReplaceSystem.GetTexture( "ItemSlots/Replace_ItemSlot_0" ).Value;
            }
            base.SetDefaults( item );
        }
        public override bool PreDrawTooltip( Item item , ReadOnlyCollection<TooltipLine> lines , ref int x , ref int y )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Main.SettingsEnabled_OpaqueBoxBehindTooltips = false;
                ToolTip.Draw( item , x , y );
                if ( item != null )
                    Main.HoverItem = item.Clone( );
            }
            return false;
        }
    }
}