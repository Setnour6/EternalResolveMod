using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Manas.Debuff
{
    public class DeMoveSpeed_12 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "乏力" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "减少12%移动速度" );

            DisplayName.AddTranslation( EternalResolve.English , "Fatigue" );
            Description.AddTranslation( EternalResolve.English ,
                "delete 12% moveSpeed" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.moveSpeed -= 0.12f;
        }
    }
}
