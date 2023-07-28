using EternalResolve.Common.Contents.Modulars.ModifyModular.Players;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.CritDamages
{
    public class CritDamage_6 : ModBuff
    {
        public override string Texture => ModContent.GetModBuff( ModContent.BuffType<CritDamage_2>( ) ).Texture;
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "暴击伤害加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得6%暴击伤害" );

            DisplayName.AddTranslation( EternalResolve.English , "Crit damage Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 6% Crit damage" );

            Main.buffNoTimeDisplay[ Type ] = false;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.AddCritDamage( 0.06f );
        }
    }
}
