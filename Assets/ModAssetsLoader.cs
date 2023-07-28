using EternalResolve.Assets.Textures;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Assets
{
    public class ModAssetsLoader : ModSystem
    {
        public static Effect DefaultEffect;

        public override void Load( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                DefaultEffect = ModContent.Request<Effect>( "EternalResolve/Effects/Effect-0" , AssetRequestMode.ImmediateLoad ).Value;
            }
            foreach ( Type type in Mod.Code.GetTypes( ) )
            {
                if ( type.IsSubclassOf( typeof( ModAssets ) ) )
                {
                    ModAssets modAssets = (ModAssets) Activator.CreateInstance( type );
                    modAssets.Load( );
                }
            }
            base.Load( );
        }

        public static Asset<Texture2D> GetTexture( string path )
        {
            return ModContent.Request<Texture2D>( "EternalResolve/Assets/" + path , AssetRequestMode.ImmediateLoad );
        }

        public static Asset<Texture2D> GetTexture2( string path )
        {
            return ModContent.Request<Texture2D>( "EternalResolve/Assets/" + path , AssetRequestMode.AsyncLoad );
        }
    }
}
