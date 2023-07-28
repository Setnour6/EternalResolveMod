using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Boxs
{
    public class OpeningBox : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "神秘宝箱" );
            DisplayName.AddTranslation( English , "Mysterious treasure chest" );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
        }
        public override int BossBagNPC => 1;

        public override bool CanRightClick( )
        {
            return true;
        }
        public override void OpenBossBag( Player player )
        {
            Projectile.NewProjectile( null , player.Center , new Vector2( 0 , -0.5f ) , ModContent.ProjectileType<OpeningBox_Effect>( ) , 0 , 0 , player.whoAmI , 0 , 0 );
        }
    }
}
