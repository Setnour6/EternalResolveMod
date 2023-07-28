using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Manas.Speeds
{
    public class ManaMoveSpeed_12 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "移速加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得12%移动速度加成" );

            DisplayName.AddTranslation( EternalResolve.English , "Move Speed Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 12% moveSpeed" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.moveSpeed += 0.12f;
        }

    }
}
