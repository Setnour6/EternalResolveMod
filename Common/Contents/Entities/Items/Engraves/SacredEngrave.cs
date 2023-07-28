using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class SacredEngrave_Power : ModPlayer
    {
        public bool Enable = false;

        protected override bool CloneNewInstances => true;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Enable )
            {
                damage -= damage / 10;
                int num = 1 + damage / 10;
                Player.addDPS( num );
                target.life -= num;
                target.checkDead( );
                CombatText.NewText( target.getRect( ) , Color.White , num );
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable )
            {
                damage -= damage / 10;
                int num = 1 + damage / 10;
                Player.addDPS( num );
                target.life -= num;
                target.checkDead( );
                CombatText.NewText( target.getRect( ) , Color.White , num );
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
    public class SacredEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "圣之刻印" );
            Tooltip.AddTranslation( Chinese , "" +
                "造成25%额外伤害\n" +
                "造成的伤害转化10%为真实伤害\n" +
                "根据你的移动速度获得额外防御\n" +
                "根据你的移动速度获得额外生命值\n" +
                "根据你的移动速度获得伤害减免" );

            DisplayName.AddTranslation( English , "Sacred Engrave" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.defense = 3;
            Item.value = Item.sellPrice( 0 , 2 );
            base.SetDefaults( );
        }

        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetModPlayer<SacredEngrave_Power>( ).Enable = true;
            player.statDefense += ( player.velocity.Length( ) ).ToInt( );
            player.statLifeMax2 += ( player.velocity.Length( ) ).ToInt( );
            player.endurance += ( player.velocity.Length( ) ).ToInt( );

            base.UpdateAccessory( player , hideVisual );
        }

        public override void AddRecipes( )
        {
            base.AddRecipes( );
        }
    }
}
