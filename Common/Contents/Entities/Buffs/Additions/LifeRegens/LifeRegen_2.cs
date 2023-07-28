using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.LifeRegens
{
    public class LifeRegen_2 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "生命回复加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得2点生命回复" );

            DisplayName.AddTranslation( EternalResolve.English , "LifeRegen Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 2 lifeRegen" );

            Main.buffNoTimeDisplay[ Type ] = false;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.lifeRegen += 2;
        }
    }
}
