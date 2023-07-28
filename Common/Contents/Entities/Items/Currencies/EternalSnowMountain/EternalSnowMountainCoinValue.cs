using EternalResolve.Assets.Textures.EternalSnowMountain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Currencies.EternalSnowMountain
{
    public class EternalSnowMountainCoinValue : GlobalItem
    {
        public override void PostDrawInInventory( Item item , SpriteBatch spriteBatch , Vector2 position , Rectangle frame , Color drawColor , Color itemColor , Vector2 origin , float scale )
        {
            if ( item.type == ModContent.ItemType<EternalSnowMountainCoin>( ) )
                spriteBatch.Draw( CoinValueAssets.Value1 , position + new Vector2( 24 - CoinValueAssets.Value1.Width / 2 , 24 ) , Color.White );
            else if ( item.type == ModContent.ItemType<EternalSnowMountainCoinValue5>( ) )
                spriteBatch.Draw( CoinValueAssets.Value5 , position + new Vector2( 24 - CoinValueAssets.Value5.Width / 2 , 24 ) , Color.White );
            else if ( item.type == ModContent.ItemType<EternalSnowMountainCoinValue10>( ) )
                spriteBatch.Draw( CoinValueAssets.Value10 , position + new Vector2( 24 - CoinValueAssets.Value10.Width / 2 , 24 ) , Color.White );
            else if ( item.type == ModContent.ItemType<EternalSnowMountainCoinValue20>( ) )
                spriteBatch.Draw( CoinValueAssets.Value20 , position + new Vector2( 24 - CoinValueAssets.Value20.Width / 2 , 24 ) , Color.White );
            else if ( item.type == ModContent.ItemType<EternalSnowMountainCoinValue50>( ) )
                spriteBatch.Draw( CoinValueAssets.Value50 , position + new Vector2( 24 - CoinValueAssets.Value50.Width / 2 , 24 ) , Color.White );
            else if ( item.type == ModContent.ItemType<EternalSnowMountainCoinValue100>( ) )
                spriteBatch.Draw( CoinValueAssets.Value100 , position + new Vector2( 24 - CoinValueAssets.Value100.Width / 2 , 24 ) , Color.White );

            base.PostDrawInInventory( item , spriteBatch , position , frame , drawColor , itemColor , origin , scale );
        }

        public override bool InstancePerEntity => true;

        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

    }
}
