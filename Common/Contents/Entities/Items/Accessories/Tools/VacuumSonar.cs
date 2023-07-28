using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Tools
{
    /// <summary>
    /// 真空声呐.
    /// </summary>
    public class VacuumSonar : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "真空声呐" );
            Tooltip.AddTranslation( Chinese , "" +
                "有了它谁还需要地图 ! \n" +
                "呐呐呐呐呐呐～" );

            DisplayName.AddTranslation( English , "Vacuum Sonar" );
            Tooltip.AddTranslation( English , "With it, you don't need map !" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 6 , 8 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            Item.defense = 1;
            Item.value = Item.sellPrice( 0 , 5 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            if ( Main.time % 10 == 0 )
            {
                int startX = (int) ( player.Center.X / 16f ) - 50;
                int startY = (int) ( player.Center.Y / 16f ) - 50;
                int endX = startX + 100;
                int endY = startY + 100;
                for ( int i = startX; i < endX; i++ )
                {
                    for ( int j = startY; j < endY; j++ )
                    {
                        if ( WorldGen.InWorld( i , j ) )
                        {
                            Main.Map.UpdateLighting( i , j , (byte) ( 200 - ( 2 * (byte) Vector2.Distance( player.Center / 16 , new Vector2( i , j ) ) ) ) );
                        }
                    }
                }
                Main.refreshMap = true;
            }
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 2 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 6 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
