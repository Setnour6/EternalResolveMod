using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Water
{
    public class WaterSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "水镰刀" );
            DisplayName.AddTranslation( English , "Water Sickle" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.width = 38;
            Item.height = 40;
            Item.damage += 6;
            Item.mana = 4;
            base.SetDefaults( );
        }
        public override void MeleeEffects( Player player , Rectangle hitbox )
        {
            for ( int i = 0; i < 3; i++ )
            {
                Dust dust = Dust.NewDustDirect( new Vector2( hitbox.X , hitbox.Y ) , hitbox.Width - 5 , hitbox.Height - 5 , DustID.Water , 0f , 0f , 0 , default( Color ) , 1f );
                dust.scale = 1.5f;
                dust.noGravity = true;
                dust.velocity = ModUtils.SpinDust( player.Center , dust.position , player.direction == 1 , 10f );
            }
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.WaterBolt ).
                Register( );
            base.AddRecipes( );
        }
    }
}
