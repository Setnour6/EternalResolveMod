
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.ShadowKillers
{
    public class ShadowKillerLoading : ModBuff
    {
        public int LeftTime = 240;
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "「手枪」暗影杀手 装填中" );
            Description.SetDefault( "" +
                "正在装填弹药！\n" +
                "  你获得50%的移动速度加成\n" +
                "30%的伤害减免" );
            Main.buffNoTimeDisplay[ Type ] = false;
            Main.buffNoSave[ Type ] = true;
            Main.debuff[ Type ] = true;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            LeftTime--;
            Player.moveSpeed += 0.25f;
            Player.endurance += 0.3f;
            ModContent.GetInstance<ShadowKillerUI>( ).ShadowKillerUIEnable = false;
            Player.delayUseItem = true;
            if ( Player.HeldItem.type != ModContent.ItemType<ShadowKiller>( ) )
            {
                Player.delayUseItem = true;
            }
            if ( LeftTime % 60 == 0 )
            {
                Engine.PlaySound( SoundID.Item149 );
                if ( Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot > 0 )
                {
                    Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot -= 1;
                }
            }
        }
    }
}
