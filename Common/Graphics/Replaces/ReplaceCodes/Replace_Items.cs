using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.GameContent;

namespace EternalResolve.Common.Graphics.Replaces.ReplaceCodes
{
    public class Replace_Items
    {
        static Asset<Texture2D>[ ] Items = new Asset<Texture2D>[ TextureAssets.Item.Length ];

        static List<int> replaceID = new List<int>( );
        public static void Replace( )
        {
            AddID( );
            for ( int count = 0; count < replaceID.Count; count++ )
                Items[ replaceID[ count ] ] = TextureAssets.Item[ replaceID[ count ] ];

            for ( int count = 0; count < replaceID.Count; count++ )
                TextureAssets.Item[ replaceID[ count ] ] = ReplaceSystem.GetTexture( "Items/Replace_Item_" + replaceID[ count ] );
        }
        static void AddID( )
        {
            replaceID.Add( 1 );
            replaceID.Add( 4 );
            replaceID.Add( 10 );
        }
        public static void UnLoad( )
        {
            for ( int count = 0; count < replaceID.Count; count++ )
                TextureAssets.Item[ replaceID[ count ] ] = Items[ replaceID[ count ] ];
        }
    }
}