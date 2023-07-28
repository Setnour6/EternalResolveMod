using EternalResolve.Common.Contents.Entities.Items.HitEffects;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Summons.Impacts
{
    public class Impact : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尘世" );
            Tooltip.AddTranslation( Chinese , "" +
                "右键可切换模式.\n" +
                "该物品在未被持握时: \n" +
                "与你共同战斗." );

            DisplayName.AddTranslation( English , "Impact" );
            Tooltip.AddTranslation( English , "" +
                "Right click to switch modes. \n" +
                "This item is not held: \n" +
                "Fight with you." );
        }

        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.DamageType = DamageClass.Summon;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
        }

        public override void UpdateInventory( Player player )
        {
            if ( player.HeldItem != Item )
            {
                if ( player.GetModPlayer<Impact_Power>( ).ImpactPower &&
                    player.ownedProjectileCounts[ ModContent.ProjectileType<Impact_Summon>( ) ] < 1 )
                    Projectile.NewProjectile( null , player.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Impact_Summon>( ) , player.statLife / 10 , 0 , player.whoAmI , 0 , 0 );
            }
            base.UpdateInventory( player );
        }
        public override void HoldItem( Player player )
        {
            if ( player == Main.LocalPlayer && !Main.LocalPlayer.mouseInterface && Main.mouseRight && Main.mouseRightRelease )
            {
                switch ( player.GetModPlayer<Impact_Power>( ).PowerType )
                {
                    case 0:
                        {
                            string text = "";
                            if ( Language.ActiveCulture == EternalResolve.Chinese )
                                text = "切换至「进攻」";
                            else if ( Language.ActiveCulture == EternalResolve.Chinese )
                                text = "Switch to「Attack」";
                            int combatText = CombatText.NewText( player.getRect( ) , Color.Orange , text );
                            Main.combatText[ combatText ].lifeTime = 72;
                            Main.combatText[ combatText ].velocity.Y = -5f;
                            player.GetModPlayer<Impact_Power>( ).PowerType = 1;
                        }
                        break;
                    case 1:
                        {
                            string text = "";
                            if ( Language.ActiveCulture == EternalResolve.Chinese )
                                text = "切换至「跟随」";
                            else if ( Language.ActiveCulture == EternalResolve.Chinese )
                                text = "Switch to「Follow」";
                            int combatText = CombatText.NewText( player.getRect( ) , Color.Green , text );
                            Main.combatText[ combatText ].lifeTime = 72;
                            Main.combatText[ combatText ].velocity.Y = -5f;
                            player.GetModPlayer<Impact_Power>( ).PowerType = 0;
                        }
                        break;
                }
            }
            base.HoldItem( player );
        }
        public override void OnHitNPC( Player player , NPC target , int damage , float knockBack , bool crit )
        {
            Projectile.NewProjectile( Projectile.InheritSource(Item) , target.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , player.whoAmI , Main.rand.NextFloat( ) , 0 ); // is null better to use for proj source?
            base.OnHitNPC( player , target , damage , knockBack , crit );
        }
    }
}
