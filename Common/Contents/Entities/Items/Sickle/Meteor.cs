using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class Meteor : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "流星镰" );
            Tooltip.AddTranslation( Chinese , "" +
                "重击敌人 , 造成混乱和流血\n" +
                "\"可以引动星体碎片的能量\"" );
        }
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.value = Item.sellPrice( 0 , 5 );
        }
        public override void MeleeEffects( Player player , Rectangle hitbox )
        {
            for ( int i = 0; i < 5; i++ )
            {
                Dust dust = Dust.NewDustDirect( new Vector2( (float) hitbox.X , (float) hitbox.Y ) , hitbox.Width - 5 , hitbox.Height - 5 , 6 , 0f , 0f , 0 , default( Color ) , 1f );
                dust.scale = 1.5f;
                dust.noGravity = true;
                dust.velocity = ModUtils.SpinDust( player.Center , dust.position , player.direction == 1 , 10f );
            }
        }
        public override void OnHitNPC( Player player , NPC target , int damage , float knockBack , bool crit )
        {
            target.AddBuff( 30 , 30 , false );
            target.AddBuff( 31 , 30 , false );
            Projectile.NewProjectile( new ERProjectileSource( ) , target.Center + new Vector2( 0f , -900f ) , new Vector2( 0f , 20f ) , 424 , Item.damage , knockBack , Main.myPlayer , 0f , 0f );
            Projectile.NewProjectile( new ERProjectileSource( ) , target.Center + new Vector2( 0f , -600f ) , new Vector2( 0f , 20f ) , 425 , Item.damage , knockBack , Main.myPlayer , 0f , 0f );
            Projectile.NewProjectile( new ERProjectileSource( ) , target.Center + new Vector2( 0f , -300f ) , new Vector2( 0f , 20f ) , 426 , Item.damage , knockBack , Main.myPlayer , 0f , 0f );
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.MeteoriteBar , 12 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}