using EternalResolve.Common.Contents.Entities.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns
{
    public class CrystalUziGreen : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "晶体Uzi" );
            DisplayName.AddTranslation( English , "Crystal Uzi" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 4 );
            Item.damage = 3;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 30f;
            Item.UseSound = SoundID.Item11;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.scale = 0.7f;
            Item.value = Item.sellPrice( 0 , 2 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            type = 89;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -3f , -3f ) );
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Emerald , 6 ).
                AddIngredient( ItemID.IllegalGunParts ).
                AddIngredient( ModContent.ItemType<LegalFirearmsParts>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}