using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace EternalResolve.Common.Contents.Entities.Items.Runes
{
    public abstract class BasicRune : ERItem
    {
        public virtual string ChineseRuneTip { get; protected set; } = "";

        public virtual string EnglishRuneTip { get; protected set; } = "";

        public override bool OnPickup( Player player )
        {
            return false;
        }

        public override void SetDefaults( )
        {
            base.SetDefaults( );
            ToRune( 4 );
            Item.scale = 0.1f;
            if ( Main.netMode != NetmodeID.Server )
            {
                Item.GetGlobalItem<ItemToolTipHack>( ).TextLine = new TextLine( "" , Color.White );
            }
        }

        public override void UpdateInventory( Player player )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                base.UpdateInventory( player );
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                {
                    Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text = "◆ 符印介绍:\n " + ChineseRuneTip;
                }
                else
                {
                    Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text = "◆ Rune introduction:\n " + EnglishRuneTip;
                }
            }
        }
    }
}