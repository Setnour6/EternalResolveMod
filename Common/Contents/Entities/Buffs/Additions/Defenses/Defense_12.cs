using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.Defenses
{
    public class Defense_12 : ModBuff
    {
        public override string Texture => ModContent.GetModBuff( ModContent.BuffType<Defense_5>( ) ).Texture;
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "防御加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得12点防御值" );

            DisplayName.AddTranslation( EternalResolve.English , "Defense Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 12 defense" );

            Main.buffNoTimeDisplay[ Type ] = false;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.statDefense += 12;
        }
    }
}
