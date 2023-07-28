using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Engraves
{
    public class OnFire_I : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "刻印之焰" );
            DisplayName.AddTranslation( EternalResolve.English , "On Fire" );
            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
            base.SetStaticDefaults( );
        }
        public override void Update( NPC npc , ref int buffIndex )
        {
            int dust = Dust.NewDust( npc.position + Vector2.One * 4 , npc.width - 2 , npc.height - 2 , DustID.FireworkFountain_Red , Main.rand.NextVector2Unit( ).X , Main.rand.NextVector2Unit( ).Y );
            Main.dust[ dust ].noGravity = true;
            if ( Main.time % 30 == 0 )
            {
                npc.StrikeNPC( npc.lifeMax / 200 + npc.defense / 2 , 0 , 0 , false );
                for ( int count = 0; count < 15; count++ )
                {
                    int n = Dust.NewDust( npc.position + Vector2.One * 4 , npc.width - 2 , npc.height - 2 , DustID.FireworkFountain_Red , Main.rand.NextVector2Unit( ).X , Main.rand.NextVector2Unit( ).Y );
                }
            }
            base.Update( npc , ref buffIndex );
        }
    }
}
