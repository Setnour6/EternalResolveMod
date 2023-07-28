using EternalResolve.Common.Contents.Entities.Items.Runes.Normal;
using EternalResolve.Common.Contents.Entities.Items.Runes.Normal.SwordMan;
using EternalResolve.Common.Contents.Modulars;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes
{
    public class RuneSaverI_Loot : GlobalNPC
    {
        public override void OnKill( NPC npc )
        {
            if ( Main.rand.Next( 250 ) == 100 )
                ERItemManager.CreateItem( npc.Center , ModContent.ItemType<RuneSaverI>( ) );
            base.OnKill( npc );
        }
    }

    public class RuneSaverI : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "「低阶」 符印存储器" );

            DisplayName.AddTranslation( English , "「Low order」 Rune saver" );

            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 12 , 5 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
            Item.value = Item.sellPrice( 0 , 5 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override int BossBagNPC => 1;

        public override bool CanRightClick( )
        {
            return true;
        }
        public static List<int> RuneList = new List<int>( )
        {
            ModContent.ItemType<Defenser>(),
            ModContent.ItemType<Concentrate>(),
            ModContent.ItemType<Sharp>(),
            ModContent.ItemType<Concentrate>(),
        };
        public override void OpenBossBag( Player player )
        {
            int rand = Main.rand.Next( 0 , RuneList.Count );
            LootRune( RuneList[ rand ] , (RuneType) rand );
        }

        public void LootRune( int type , RuneType runeType )
        {
            for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
            {
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    if ( Item.type != ItemID.None && Modular.RuneInterface.Inventory.Slot[ x , y ].Item.type == ItemID.None )
                    {
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( type );
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.GetGlobalItem<RuneItem>( ).RuneType = runeType;
                        CombatText.NewText( Main.LocalPlayer.getRect( ) , Color.BlueViolet , "获得符印 " + new Item( type ).Name );
                        return;
                    }
                }
            }
        }
    }
}