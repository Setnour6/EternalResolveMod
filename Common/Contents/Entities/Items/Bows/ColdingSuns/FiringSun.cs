using EternalResolve.Common.Contents.Modulars;
using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.ColdingSuns
{
    public class FiringSun : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "重燃的烈阳" );

            DisplayName.AddTranslation( English , "Reforging Sun" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBow( 9 );
            Item.useTime = 9;
            Item.useAnimation = 19;
            Item.reuseDelay = 20;
            Item.UseSound = null;
            Item.shootSpeed = 14;
            Item.value = Item.sellPrice( 2 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2( -6 , 0 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            position = player.Center + Main.rand.NextVector2Unit( ) * 20;
            Engine.PlaySound( SoundID.Item5 , player.Center );
            type = ModContent.ProjectileType<SunStar>( );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override void ModifyWeaponDamage( Player player , ref StatModifier damage , ref float flat )
        {
            Item.damage = 20;
            if ( NPC.downedSlimeKing )
                Item.damage += 4;
            if ( NPC.downedBoss1 )
                Item.damage += 4;
            if ( NPC.downedBoss2 )
                Item.damage += 4;
            if ( NPC.downedBoss3 )
            {
                Item.damage += 10;
                Item.useTime = 6;
            }
            if ( NPC.downedMechBoss1 )
                Item.damage += 6;
            if ( NPC.downedMechBoss2 )
                Item.damage += 6;
            if ( NPC.downedMechBoss3 )
                Item.damage += 6;
            if ( NPC.downedPlantBoss )
                Item.damage += 10;
            if ( NPC.downedEmpressOfLight )
                Item.damage += 6;
            if ( NPC.downedGolemBoss )
                Item.damage += 10;

            base.ModifyWeaponDamage( player , ref damage , ref flat );
        }
        public override void UpdateInventory( Player player )
        {
            Item.GetGlobalItem<ItemToolTipHack>( ).TextLine = new TextLine( "" +
                "◆ 该武器是成长型武器\n" +
                "  具体的信息请查阅Wiki" , Color.GreenYellow );

            base.UpdateInventory( player );
        }
    }
}