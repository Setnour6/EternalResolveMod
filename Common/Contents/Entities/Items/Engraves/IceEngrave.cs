using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class IceEngrave_Accessories : ModPlayer
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
                target.buffImmune[ BuffID.Frostburn ] = false;
                target.AddBuff( BuffID.Frostburn , 180 );
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable )
            {
                target.buffImmune[ BuffID.Frostburn ] = false;
                target.AddBuff( BuffID.Frostburn , 180 );
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }

    public class IceEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "冰之刻印" );
            DisplayName.AddTranslation( English , "Ice Engrave" );

            Tooltip.AddTranslation( Chinese , "" +
                "允许你在冰上行走\n" +
                "无视霜火\n" +
                "无视冻结\n" +
                "允许你在极地无限飞行\n" +
                "你的攻击必定造成霜火\n" +
                "持续三秒" );

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
            player.iceSkate = true;
            player.buffImmune[ BuffID.Frostburn ] = true;
            player.buffImmune[ BuffID.Frostburn2 ] = true;
            player.buffImmune[ BuffID.Frozen ] = true;

            player.GetModPlayer<IceEngrave_Accessories>( ).Enable = true;

            if ( player.ZoneSnow )
            {
                player.wingTime = 2;
            }
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Engrave>( ) , 1 ).
                AddIngredient( ItemID.Snowball , 2048 ).
                AddIngredient( ItemID.IceBlock , 512 ).
                AddIngredient( ItemID.Cloud , 128 ).
                AddIngredient( ItemID.IceBlade , 1 ).
                AddIngredient( ItemID.IceMachine , 1 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}