using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Others
{
    public class Drunk : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "喝醉了" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得80%近战伤害加成\n" +
                "失去所有防御\n" +
                "增加12%移动速度" );

            DisplayName.AddTranslation( EternalResolve.English , "Drunk" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 80% melee damage\n" +
                "Lose all defense\n" +
                "Add 12% moveSpeed" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player player , ref int buffIndex )
        {
            player.GetDamage( DamageClass.Melee ) += 0.8f;
            player.statDefense = 0;
            player.moveSpeed += 0.12f;
            player.maxRunSpeed += 0.12f;
            base.Update( player , ref buffIndex );
        }
    }
}