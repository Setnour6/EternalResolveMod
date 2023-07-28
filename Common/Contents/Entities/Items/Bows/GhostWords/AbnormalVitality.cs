using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class AbnormalVitality : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "畸形生机-AbnormalVitality" );
            Main.debuff[ Type ] = false;
            Main.buffNoSave[ Type ] = false;
            Main.buffNoTimeDisplay[ Type ] = false;
            base.SetStaticDefaults( );
        }
        public override void Update( NPC npc , ref int buffIndex )
        {
            if ( Main.time % 60 == 0 )
            {
                npc.StrikeNPC( npc.lifeMax / 50 + npc.defense / 2 , 0 , 0 , false );
            }
            Vector2 position = npc.Center;
            Dust dust = Main.dust[ Dust.NewDust( position , npc.width , npc.height , DustID.UnusedWhiteBluePurple ,
                -npc.velocity.X / 8f , -npc.velocity.Y / 8f , 0 , new Color( 0 , 17 , 255 ) , 3.092105f ) ];
            dust.noGravity = true;
            dust.fadeIn = 3f;
            base.Update( npc , ref buffIndex );
        }
    }
}