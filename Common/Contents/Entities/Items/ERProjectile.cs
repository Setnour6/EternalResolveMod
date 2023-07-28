using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items
{
    public abstract class ERProjectile : ModProjectile
    {
        public GameCulture Chinese = GameCulture.FromCultureName( GameCulture.CultureName.Chinese );

        public GameCulture English = GameCulture.FromCultureName( GameCulture.CultureName.English );

        public void ToProjectile( int width , int height )
        {
            Projectile.aiStyle = -1;
            Projectile.width = width;
            Projectile.height = height;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 600;
        }

        /// <summary>
        /// 跟随.
        /// </summary>
        /// <param name="projectil"></param>
        /// <param name="target"></param>
        /// <param name="weightfactor"></param>
        public void Follow( Vector2 target )
        {
            Vector2 targetVec = target - Projectile.Center;
            targetVec.Normalize( );
            targetVec *= 20f;
            Projectile.velocity = ( Projectile.velocity * 100f + targetVec ) / 101f;
        }

        /// <summary>
        ///冲刺.
        /// </summary>
        /// <param name="projectil"></param>
        /// <param name="target"></param>
        /// <param name="weightfactor"></param>
        public void Sprint( Vector2 target )
        {
            float progressiveFactor = 32f;
            Vector2 targetPos = Vector2.Normalize( target - Projectile.Center ) * progressiveFactor;
            Projectile.velocity = ( Projectile.velocity * 29 + targetPos ) / 30;
        }
    }
}
