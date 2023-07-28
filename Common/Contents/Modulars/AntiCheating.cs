using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars
{
    /// <summary>
    /// 反作弊系统.
    /// </summary>
    public class AntiCheating : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public string UUID = "";

        /// <summary>
        /// 表示该物品来自正规渠道.
        /// </summary>
        public bool FormalChannel = true;

        public string Authentication = "";

        public override GlobalItem Clone( Item Item , Item ItemClone ) => base.Clone( Item , ItemClone );

        public override void LoadData( Item Item , TagCompound tag )
        {

            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = tag.GetBool( "FormalChannel" );
            Item.GetGlobalItem<AntiCheating>( ).UUID = tag.GetString( "UUID" );
        }
        public override void SaveData( Item item , TagCompound tag )
        {
            tag.Add( "FormalChannel" , item.GetGlobalItem<AntiCheating>( ).FormalChannel );
            tag.Add( "UUID" , item.GetGlobalItem<AntiCheating>( ).UUID );
        }

        public override void SetDefaults( Item item )
        {
            if ( item.UUID( ) == string.Empty )
                item.CreateUUID( );
            base.SetDefaults( item );
        }

        int oldStack = 0;
        int stack = 0;
        public override void UpdateInventory( Item Item , Player Player )
        {
            if ( Main.gameTimeCache.ElapsedGameTime.TotalSeconds > 1 )
            {
                oldStack = stack;
                stack = Item.stack;
                if ( oldStack != stack )
                    Item.CreateUUID( );
            }
            base.UpdateInventory( Item , Player );
        }

        public override void OnCreate( Item Item , ItemCreationContext context )
        {
            Item.CreateUUID( );
            if ( Item.ModItem != null )
                Item.ModItem.Item.CreateUUID( );
            base.OnCreate( Item , context );
        }

        internal string CreateUUID( )
        {
            string result = "";
            string[ ] texts = new string[ 8 ];
            for ( int stringCount = 0; stringCount < texts.Length; stringCount++ )
            {
                texts[ stringCount ] =
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ] +
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ] +
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ];
            }
            foreach ( string text in texts )
            {
                result += text;
            }
            return result;
        }
    }

    public class AntiCheatingSystem : ModSystem
    {
        internal static bool Enable = true;

        public override void PostUpdateEverything( )
        {
            if ( Enable )
            {
                if ( Main.mouseItem != null &&
                    Main.mouseItem.type != ItemID.None &&
                    !Main.mouseItem.GetGlobalItem<AntiCheating>( ).FormalChannel )
                {
                    if ( Language.ActiveCulture == EternalResolve.Chinese )
                        CombatText.NewText( Main.LocalPlayer.getRect( ) , Color.Red , "物品来源不明" );
                    else if ( Language.ActiveCulture == EternalResolve.Chinese )
                        CombatText.NewText( Main.LocalPlayer.getRect( ) , Color.Red , "Item Error" );
                    Main.mouseItem.SetDefaults( 0 );
                }
            }
            base.PostUpdateEverything( );
        }

        public override void PostWorldGen( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                foreach ( Chest chest in Main.chest )
                {
                    if ( chest != null )
                    {
                        foreach ( Item chestItem in chest.item )
                        {
                            if ( chestItem != null && chestItem.type != ItemID.None )
                            {
                                chestItem.CreateUUID( );
                                chestItem.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                            }
                        }
                    }
                }
            }
            base.PostWorldGen( );
        }
    }

    public static class AntiCheatingUtils
    {
        public static string UUID( this Item item )
        {
            return item.GetGlobalItem<AntiCheating>( ).UUID;
        }
        public static void CreateUUID( this Item item )
        {
            item.GetGlobalItem<AntiCheating>( ).UUID = item.GetGlobalItem<AntiCheating>( ).CreateUUID( );
        }
    }
}