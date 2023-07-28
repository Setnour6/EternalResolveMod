using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.RedRiots
{
    public class RedRiot : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "赤红暴乱" );
            Tooltip.AddTranslation( Chinese , "" +
                "首先进行3次斩击，若命中敌人即可触发接下来的8次快速斩击.\n" +
                "每一次斩击都会使下一次斩击的伤害翻倍.\n" +
                "并为你回复10-20点生命值." );

            DisplayName.AddTranslation( English , "Crimson · Rebellion" );
            Tooltip.AddTranslation( English , "" +
                "First make 3 chopping blows. If you hit the enemy, you can trigger the next 8 quick chopping blows. \n" +
                "Each chop will double the damage of the next chop. \n" +
                "And restore 10-20 HP for you." );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 6 , 28 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;

        }
        public override void SetDefaults( )
        {
            ToSword( 7 );
            Item.damage += 30;
            Item.useTime = Item.useAnimation;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item71;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<RedRiotChop>( );
            Item.value = Item.sellPrice( 0 , 50 );
            Item.shootSpeed = 1f;
        }
        public override void HoldItem( Player player )
        {
            Lighting.AddLight( player.Center , new Vector3( 1f , 0.2f , 0.2f ) );
            base.HoldItem( player );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Broken>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 12 ).
                AddIngredient( ModContent.ItemType<SlashSoul>( ) , 64 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 64 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 32 ).
                AddIngredient( ItemID.HallowedBar , 32 ).
                AddIngredient( ItemID.Katana , 1 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
            base.AddRecipes( );
        }
    }
}
