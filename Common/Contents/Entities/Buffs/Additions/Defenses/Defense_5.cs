using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.Defenses
{
    public class Defense_5 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "防御加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得5点防御值" );

            DisplayName.AddTranslation( EternalResolve.English , "Defense Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 5 defense" );

            Main.buffNoTimeDisplay[ Type ] = false;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.statDefense += 5;
        }
    }
}
