using Terraria;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Buffs.Manas.Damages
{
    public class MeleeDamage_8 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "近战攻击加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得8%近战伤害加成" );

            DisplayName.AddTranslation( EternalResolve.English , "Melee Damage Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 8% melee damage" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player player , ref int buffIndex )
        {
            player.GetDamage( DamageClass.Melee ) += 0.08f;
            base.Update( player , ref buffIndex );
        }
    }
}
