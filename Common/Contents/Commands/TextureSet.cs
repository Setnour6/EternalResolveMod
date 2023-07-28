using EternalResolve.Common.Graphics.Replaces.ReplaceCodes;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Commands
{
    public class TextureSet : ModCommand
    {
        public override CommandType Type
            => CommandType.Chat;

        public override string Command
            => "TextureSet";

        public override string Usage
            => "/TextureSet <code>";

        public override string Description
            => "替换材质包风格";

        public override void Action( CommandCaller caller , string input , string[ ] args )
        {
            if ( Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( input.Contains( "Myth" ) )
                {
                    Replace_Myth.Replace( );
                }
                if ( input.Contains( "EternalResolve" ) )
                {
                    Replace_ItemSlots.Replace( );
                }
            }
        }
    }
}