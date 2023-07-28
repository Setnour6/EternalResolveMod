using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Buffs.Additions.MoveSpeeds
{
    public class MoveSpeed_12 : ModBuff
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "移动速度加成" );
            Description.AddTranslation( EternalResolve.Chinese ,
                "获得12%移动速度" );

            DisplayName.AddTranslation( EternalResolve.English , "Move speed Add" );
            Description.AddTranslation( EternalResolve.English ,
                "Add 12% move speed" );

            Main.buffNoTimeDisplay[ Type ] = true;
            Main.buffNoSave[ Type ] = false;
            Main.debuff[ Type ] = false;
        }
        public override void Update( Player Player , ref int buffIndex )
        {
            Player.moveSpeed += 0.12f;
            Player.maxRunSpeed += 0.12f;
        }
    }
}