using EternalResolve.Common.Contents.Modulars;
using EternalResolve.Common.Contents.Modulars.RingModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class ArimiRing_Power : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public bool Enable = false;

        int _counter = 0;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Enable )
            {
                //   if ( target.type == ModContent.NPCType<StarMagicStone>( )  )
                {
                    damage = target.lifeMax * 2;
                }
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable )
            {
                //        if ( target.type == ModContent.NPCType<StarMagicStone>( ) )
                {
                    damage = target.lifeMax * 2;
                }
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
        public override void ModifyShootStats( Item item , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            if ( Enable )
            {
                _counter++;
                if ( _counter % 3 == 0 )
                {
                    _counter = 0;
                    Projectile.NewProjectile( new ERProjectileSource( ) , position , velocity , ModContent.ProjectileType<ArimiRing_Pro>( ) , damage , knockback , Main.myPlayer , 0 , 0 );
                }
            }
            base.ModifyShootStats( item , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
    }
    public class ArimiRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "阿瑞米之戒" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加5000\n" +
                "你可以处决摘星者\n" +
                "攻击时会顺带发射小型激光" );

            DisplayName.AddTranslation( English , "Arimi Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 5000" +
                "You can execute the Star Picker\n" +
                "A small laser will be emitted during the attack" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 2 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 5000;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetModPlayer<ArimiRing_Power>( ).Enable = true;
            base.UpdateAccessory( player , hideVisual );
        }
    }
}
