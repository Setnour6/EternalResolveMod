using EternalResolve.Common.Contents.Modulars;
using EternalResolve.Common.Contents.Modulars.CleanBeadStoneModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Currencies
{
    public class CleanStongLoot : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override bool CloneNewInstances => true;

        public override void OnKill( NPC npc )
        {
            if ( Main.netMode == NetmodeID.SinglePlayer )
            {
                if ( !npc.SpawnedFromStatue && Main.rand.Next( 100 ) <= 10 && Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD == 0 )
                {
                    Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD = 600;
                    ERItemManager.CreateItem( npc.Center , ModContent.ItemType<CleanStone>( ) , Main.rand.Next( 1 , 3 ) );
                }
            }
            else
            {
                if ( !npc.SpawnedFromStatue && Main.rand.Next( 8 , 10 ) == 9 && Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD == 0 )
                {
                    Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD = 600;
                    npc.DropItemInstanced( npc.Center , npc.Size , ModContent.ItemType<CleanStone>( ) , Main.rand.Next( 2 , 4 ) );
                }
            }
            base.OnKill( npc );
        }
    }

    public class CleanBeadStoneMouseCheck : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public int LootCD = 600;

        public override void PostUpdate( )
        {
            if ( Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD > 0 )
                    LootCD--;
                if ( Main.LocalPlayer.GetModPlayer<CleanBeadStoneMouseCheck>( ).LootCD < 0 )
                    LootCD = 0;
            }
            base.PostUpdate( );
        }
    }

    public class CleanStone : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "洁玥石" );
            Tooltip.AddTranslation( Chinese , "" +
                "可用于祈愿" );

            DisplayName.AddTranslation( English , "Sacred Keystone" );
            Tooltip.AddTranslation( English , "" +
                "Can be used to pray" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 6 );
            Item.maxStack = 99999;
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override bool OnPickup( Player player )
        {
            if ( Language.ActiveCulture == EternalResolve.Chinese )
                CombatText.NewText( Main.LocalPlayer.getRect( ) , Color.Gold , "获得了 洁玥石 x" + Item.stack );
            else if ( Language.ActiveCulture == EternalResolve.Chinese )
                CombatText.NewText( Main.LocalPlayer.getRect( ) , Color.Gold , "Get Sacred Keystone x" + Item.stack );
            player.GetModPlayer<RecordCurrency>( ).CleanBeadStone += Item.stack;
            return false;
        }
    }
}