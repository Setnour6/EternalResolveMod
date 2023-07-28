using EternalResolve.Common.Contents.Entities.Buffs.Engraves;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class FireEngrave_Accessories : ModPlayer
    {
        public bool Enable = false;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Enable )
            {
                if ( target.TypeName.Contains( "Slime" ) || target.TypeName.Contains( "slime" ) || target.TypeName.Contains( "史莱姆" ) )
                {
                    damage *= 2;
                }
                target.AddBuff( ModContent.BuffType<OnFire_I>( ) , 300 );
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable )
            {
                if ( target.TypeName.Contains( "Slime" ) || target.TypeName.Contains( "slime" ) || target.TypeName.Contains( "史莱姆" ) )
                {
                    damage *= 2;
                }
                target.AddBuff( ModContent.BuffType<OnFire_I>( ) , 300 );
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
    public class FireEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "火之刻印" );
            Tooltip.AddTranslation( Chinese , "" +
                "免疫熔岩\n" +
                "无视烧伤\n" +
                "允许你凭空使用一小段时间的火箭靴\n" +
                "若你装备了翅膀, 则替换为增加飞行时长\n" +
                "对史莱姆类生物造成200%的伤害\n" +
                "命中敌人时:\n" +
                "为其附加 刻印之焰 \n" +
                "每秒造成敌人最大生命值0.5%的真实伤害\n" +
                "持续5秒" );

            DisplayName.AddTranslation( English , "Fire Engrave" );

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
            player.lavaImmune = true;
            player.rocketBoots = 120;
            player.fireWalk = true;
            player.buffImmune[ BuffID.OnFire ] = true;
            player.buffImmune[ BuffID.OnFire3 ] = true;
            player.GetModPlayer<FireEngrave_Accessories>( ).Enable = true;
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Engrave>( ) , 1 ).
                AddIngredient( ItemID.Gel , 512 ).
                AddIngredient( ItemID.MeteoriteBar , 32 ).
                AddIngredient( ItemID.HellstoneBar , 32 ).
                AddIngredient( ItemID.RocketBoots , 1 ).
                AddIngredient( ItemID.Hellforge , 1 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}
