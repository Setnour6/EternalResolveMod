using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns
{
    public class Duke : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "公爵" );
            DisplayName.AddTranslation( English , "Duke" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 3 );
            Item.damage += 42;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;
            Item.value = Item.sellPrice( 0 , 5 );
        }

        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            type = 242;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -10f , 1.1f ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<EarthenMuskets>( ) , 1 ).
            AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 12 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 6 ).
             AddIngredient( ModContent.ItemType<LegalFirearmsParts>( ) ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
            Register( );
            base.AddRecipes( );
        }
    }
}