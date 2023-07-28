using EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class DeathEngrave_Power : ModPlayer
    {
        public bool Enable = false;

        public override bool CloneNewInstances => true;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Enable )
            {
                if ( target.defense > 50 )
                {
                    target.defense -= 5;
                }
                if ( damage < 20 )
                {
                    damage = 20;
                }
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable )
            {
                if ( target.defense > 50 )
                {
                    target.defense -= 5;
                }
                if ( damage < 20 && target.boss )
                {
                    damage = 20;
                }
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
    public class DeathEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "死之刻印" );
            DisplayName.AddTranslation( Chinese , "Death Engrave" );

            Tooltip.AddTranslation( Chinese , "" +
                "增加25点护甲穿透\n" +
                "你的攻击对Boss造成的伤害不会低于20点" +
                "你的每次攻击对防御值高于50的生物造成永久的5点护甲削除" );
            Tooltip.AddTranslation( English , "" +
                "Add 25 armorPenetration\n" +
                "Your attack will cause no less than 20 damage to the boss\n" +
                "Each time you attack, you deal a permanent 5-point armor cut to creatures with a defense of more than 50" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DeadBone>( ) ).
                AddIngredient( ModContent.ItemType<TeethOfKersuluEye>( ) ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 16 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}