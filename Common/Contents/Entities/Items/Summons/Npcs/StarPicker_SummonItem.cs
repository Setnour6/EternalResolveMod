using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Summons.Npcs
{
    public class StarPicker_SummonItem : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "星之魔石碎片" );
            DisplayName.AddTranslation( English , "StarPicker Summon Item" );
            ItemID.Sets.SortingPriorityBossSpawns[ Type ] = 12;
            //      NPCID.Sets.MPAllowedEnemies[ ModContent.NPCType<StarMagicStone>() ] = true;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.consumable = true;
            base.SetDefaults( );
        }
        public override bool CanUseItem( Player player )
        {
            return false;// !NPC.AnyNPCs( ModContent.NPCType<StarMagicStone>( ) ) && !Main.dayTime;
        }

        public override bool? UseItem( Player player )
        {
            if ( player.whoAmI == Main.myPlayer )
            {
                if ( !Main.dayTime )
                {
                    //          NPC.SpawnOnPlayer( player.whoAmI , ModContent.NPCType<StarMagicStone>( ) );
                }
            }
            return true;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.FallenStar , 49 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) ).
                AddTile( TileID.WorkBenches ).
                Register( );
            base.AddRecipes( );
        }
    }
}
