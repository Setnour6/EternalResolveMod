using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Sword
{
    public class DeeperColdSword_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒剑" ); // The English name of the projectile
            DisplayName.AddTranslation( English , "Deeper Cold Sword" ); // The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 10;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 4 , 4 );
            Projectile.penetrate = 10;
            Projectile.tileCollide = false;
            base.SetDefaults( );
        }
        public override bool OnTileCollide( Vector2 oldVelocity )
        {
            Projectile.ai[ 0 ] += 12;
            return true;
        }
        public override void ModifyHitNPC( NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            target.buffImmune[ BuffID.Frostburn ] = false;
            target.AddBuff( BuffID.Frostburn , 180 );
            ModUtils.DustCircle( DustID.IceTorch , Projectile.position , 0.3f , 12 );
            base.ModifyHitNPC( target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
        public override void AI( )
        {
            Projectile.rotation = Projectile.velocity.ToRotation( );
            Projectile.ai[ 0 ]++;
            if ( Projectile.ai[ 0 ] <= 12 )
            {
                Projectile.velocity *= 1.08f;
            }
            else
                Projectile.velocity *= 0.9f;

            if ( Projectile.velocity.Length( ) < 2f )
            {
                Projectile.ai[ 1 ]++;
                Projectile.rotation += Projectile.ai[ 1 ] * 0.36f;
            }
            if ( Projectile.ai[ 1 ] >= 72 )
            {
                Projectile.alpha += 15;
            }
            if ( Projectile.alpha >= 254 )
            {
                ModUtils.DustCircle( DustID.IceTorch , Projectile.position , 0.3f , 36 );

                Projectile.Kill( );
            }

            base.AI( );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            lightColor = Color.CadetBlue;
            lightColor.A = 0;
            Texture2D texture = TextureAssets.Projectile[ Projectile.type ].Value;
            Vector2 drawOrigin = new Vector2( texture.Width * 0.5f , texture.Height * 0.5f );
            Vector2 drawPos = Projectile.position - Main.screenPosition + new Vector2( 0f , Projectile.gfxOffY );
            Color color = Projectile.GetAlpha( lightColor );
            Main.spriteBatch.Draw( texture , drawPos , null , color , Projectile.rotation , drawOrigin , Projectile.scale , SpriteEffects.None , 0 );
            TrailDrawer trailDrawer = new TrailDrawer( );
            trailDrawer.Projectile = Projectile;
            trailDrawer.Texture0 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture1 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture2 = ExtraAssets.Extra[ 13 ];
            trailDrawer.TrailColor = Color.CadetBlue;
            trailDrawer.Opacity = 3f;
            trailDrawer.Saturation = 1.0f;
            trailDrawer.Width = 32;
            trailDrawer.Draw( );
            return false;
        }
    }
}