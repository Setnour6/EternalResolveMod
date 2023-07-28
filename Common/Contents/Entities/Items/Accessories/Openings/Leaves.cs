using EternalResolve.Common.Contents.Entities.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Openings
{
    public class Leaves : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "叶落无声" );
            DisplayName.AddTranslation( English , "Leaves" );
            Tooltip.AddTranslation( Chinese , "" +
                "应征某人愿望诞生之物\n" +
                "自动攻击1000码内敌人\n" +
                "造成10 + 25%防御值的伤害" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            Item.defense = 1;
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            if ( Main.time % 360 == 0 )
            {
                foreach ( NPC npc in Main.npc )
                {
                    if ( npc.active && !npc.friendly && npc.Distance( player.Center ) < 1000 )
                    {
                        Engine.PlaySound( SoundID.Item30 );
                        int whoAml = Projectile.NewProjectile(null ,
                    player.Center , Vector2.Normalize( npc.Center - player.Center ) * 10f , 206 , 10 + player.statDefense / 4 , 0 , player.whoAmI , 0 , 0 );
                        Main.projectile[ whoAml ].tileCollide = false;
                        Main.projectile[ whoAml ].timeLeft = 600;
                    }
                }
            }
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Wood , 16 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
                AddTile( TileID.WorkBenches ).
                Register( );
            base.AddRecipes( );
        }
    }
}