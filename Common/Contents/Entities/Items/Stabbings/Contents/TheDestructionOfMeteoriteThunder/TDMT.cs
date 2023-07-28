using EternalResolve.Common.Contents.Entities.Items.ArcSwords.BlueDaggers;
using EternalResolve.Common.Contents.Entities.Items.Engraves;
using EternalResolve.Common.Contents.Entities.Items.Guns.DreamInterpreters;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.TheDestructionOfMeteoriteThunder
{
    public class TDMT : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "陨雷之劫" );
            DisplayName.AddTranslation( English , "The destruction of Meteorite Thunder" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 7 );
            Item.damage = 24;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 50 , 25 );
            Item.shoot = ModContent.ProjectileType<TDMT_Pro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<ThunderEngrave>( ) , 1 ).
                AddIngredient( ModContent.ItemType<DreamInterpreter_Sword>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}