using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;

namespace EternalResolve
{
    public class Engine
    {
        public static void PlaySound( int type )
        {
            SoundEngine.PlaySound( type );
        }
        public static void PlaySound( LegacySoundStyle type )
        {
            SoundEngine.PlaySound( type );
        }
        public static void PlaySound( int type , Vector2 pos , int style = 1 )
        {
            SoundEngine.PlaySound( type , pos , style );
        }
        public static void PlaySound( LegacySoundStyle type , Vector2 pos )
        {
            SoundEngine.PlaySound( type , pos );
        }
        public static void PlaySound( int type , int x = -1 , int y = -1 , int style = 1 , float volumeScale = 1f , float pitchOffset = 0f )
        {
            SoundEngine.PlaySound( type , x , y , style , volumeScale , pitchOffset );
        }

        public static void AddBuff( Player player , int buffType , int time )
        {
            player.AddBuff( buffType , time );
        }
    }
}