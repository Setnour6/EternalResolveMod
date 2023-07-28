using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.ManaMaxs
{
    public class ManaMax_40 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "魔力上限加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得40点魔力上限" );

            DisplayName.AddTranslation( EternalResolve.English , "ManaMax Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 40 manaMax" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.statManaMax2 += 40;
        }
    }
}
