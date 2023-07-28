using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Guns
{
    public class EarthenMuskets : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "土制火枪" );
            DisplayName.AddTranslation( English , "Earthen Muskets" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 2 );
            Item.damage = 26;
            Item.crit = 4;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -9f , 0f ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.Wood , 16 ).
            AddIngredient( ItemID.LeadBar , 2 ).
            AddTile( TileID.Anvils ).
            Register( );
            CreateRecipe( ).
            AddIngredient( ItemID.Wood , 16 ).
            AddIngredient( ItemID.IronBar , 2 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}