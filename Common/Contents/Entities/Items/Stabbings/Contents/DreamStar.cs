using EternalResolve.Common.Contents.Modulars.RefineSystemModular;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents
{
    public class DreamStar : LevelItem
    {
        public override string[ ] ChineseText => new string[ ]
        {
             "◆ 攻击无视目标25%防御",
             "◆ 攻击无视目标50%防御",
             "◆ 攻击无视目标75%防御",
             "◆ 攻击无视目标100%防御",
             "◆ 攻击额外造成玩家10%最大魔力值的伤害"
        };
        public override string[ ] EnglishText => new string[ ]
        {
            "◆ Ignore enemy defense by 25%",
            "◆ Ignore enemy defense by 50%",
            "◆ Ignore enemy defense by 75%",
            "◆ Ignore enemy defense by 100%",
            "◆ Dealing extra damage equals to 10% of your max mana"
        };
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "圣器 · 梦辰星" );
            DisplayName.AddTranslation( English , "Dream Star" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 4 );
            Item.damage = 14;
            Item.knockBack = 1.5f;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.shoot = ModContent.ProjectileType<DreamStar_Pro>( );
            Item.GetGlobalItem<WeaponRefine>( ).CanLevelUp = true;
            Item.GetGlobalItem<WeaponRefine>( ).LevelMax = 5;
            base.SetDefaults( );
        }
    }
}