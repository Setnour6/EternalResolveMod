using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.ShadowKillers
{
    public class ShadowKiller : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "暗影杀手" );
            DisplayName.AddTranslation( English , "ShadowKiller" );
            Tooltip.AddTranslation( Chinese , "" +
                "暗影杀手有四发子弹，打空弹药后需要重新装填.\n" +
                "  装填过程中获得50%的移动速度加成，30%的伤害减免.\n" +
                "暗影杀手的攻击速度永远只有 1次 / 0.9秒\n" +
                "攻击速度的加成将会转化为 （（0.9 - 攻击速度）* 50%）的攻击力.\n" +
                "  暗影杀手的第四枪\n:" +
                "  将必定暴击且对生命值低于25%的敌人造成200%的伤害." );

            Tooltip.AddTranslation( English , "" +
            "The shadow killer has four bullets. It needs to be reloaded after the ammunition is empty. \n" +
            "Gain 50% movement speed bonus and 30% damage reduction during loading. \n" +
            "The attack speed of shadow killer is always only 1 time / 0.9 seconds \n" +
            "The bonus of attack speed will be converted into ((0.9 - attack speed) * 50%) attack power. \n" +
            "Shadow killer's fourth shot \n:" +
            "Will surely critically hit and cause 200% damage to enemies whose HP is less than 25%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToGun( 7 );
            Item.damage = 150;
            Item.useAnimation = 54;
            Item.useTime = 54;
            Item.crit = 0;
            Item.autoReuse = false;
            Item.value = Item.sellPrice( 0 , 30 );
            Item.shootSpeed = 24;
            base.SetDefaults( );
        }
        public override void Update( ref float gravity , ref float maxFallSpeed )
        {
            Lighting.AddLight( Item.Center , 1.1f , 0 , 1.2f );
            base.Update( ref gravity , ref maxFallSpeed );
        }
        public override void UpdateInventory( Player Player )
        {
            Item.damage = 50 + ( 54 - Item.useTime ) / 2;// （54 - 攻击间隔）* 50%
            if ( Item.GetGlobalItem<ShadowKillerCounter>( ).TheShoot == 3 )
                Item.shootSpeed = 24;
            else
                Item.shootSpeed = 16;

            base.UpdateInventory( Player );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2( -4 , 0 );
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if ( Item.GetGlobalItem<ShadowKillerCounter>( ).TheShoot == 4 )
            {
                Engine.PlaySound( SoundID.Item14 );
                Projectile.NewProjectile( source , position , velocity , ModContent.ProjectileType<ShadowKillerProj>( ) ,
                    Item.damage , Item.knockBack , Main.myPlayer , 1 , 0 );
            }
            else
            {
                Engine.PlaySound( SoundID.Item36 );

                Projectile.NewProjectile( source , position , velocity , ModContent.ProjectileType<ShadowKillerProj>( ) ,
                    Item.damage , Item.knockBack , Main.myPlayer , 0 , 0 );
            }
            return false;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 12 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 12 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 12 ).
                AddIngredient( ItemID.PhoenixBlaster , 12 ).
                AddIngredient( ItemID.HallowedBar , 12 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
            base.AddRecipes( );
        }
    }
    public class ShadowKillerCounter : GlobalItem
    {
        public int TheShoot = 3;

        public override void SetDefaults( Item Item )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                TheShoot = 0;
            }
            base.SetDefaults( Item );
        }
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item Item , Item ItemClone )
        {
            return base.Clone( Item , ItemClone );
        }
    }
    public class ShadowKillerPlayer : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if ( Player.HeldItem.type != ItemID.None )
            {
                if ( Player.HeldItem.type == ModContent.ItemType<ShadowKiller>( ) )
                {
                    if ( Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot == 3 )
                    {
                        Player.AddBuff( ModContent.BuffType<ShadowKillerLoading>( ) , 240 );
                        Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot = 4;
                    }
                    else if ( Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot >= 0 )
                        Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot += 1;
                }
            }
            return true;
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Player.HeldItem.type != ItemID.None )
            {
                if ( proj.type == ModContent.ProjectileType<ShadowKillerProj>( ) && Player.HeldItem.type == ModContent.ItemType<ShadowKiller>( ) )
                {
                    if ( Player.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot == 4 )
                    {
                        crit = true;
                        if ( target.life < ( target.lifeMax * 0.25f ).ToInt( ) )
                            damage += damage; // 200%
                    }
                }
            }

            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }

    public class ShadowKillerDrawLayer : GameInterfaceLayer
    {
        Texture2D Bottom;

        Texture2D Top;

        public ShadowKillerDrawLayer( ) : base( "ShadowKillerDrawLayer" , InterfaceScaleType.Game )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                Bottom = ModContent.Request<Texture2D>( "EternalResolve/Common/Contents/Entities/Items/Guns/" +
           "ShadowKillers/ItemUI/TheShootBottomPanel" ).Value;
                Top = ModContent.Request<Texture2D>( "EternalResolve/Common/Contents/Entities/Items/Guns/" +
            "ShadowKillers/ItemUI/TheShootTopPanel" ).Value;
            }
        }
        protected override bool DrawSelf( )
        {
            Vector2 drawPos = Main.LocalPlayer.Center - Main.screenPosition - Bottom.Size( ) / 2 - Vector2.UnitY * 76;
            if ( Main.LocalPlayer.HeldItem.type != ItemID.None )
            {
                if ( Main.LocalPlayer.HeldItem.type == ModContent.ItemType<ShadowKiller>( ) )
                {
                    Main.spriteBatch.Draw( Bottom , new Vector2( drawPos.X.ToInt( ) , drawPos.Y.ToInt( ) ) , Color.White );
                    Main.spriteBatch.Draw( Top , new Vector2( drawPos.X.ToInt( ) , drawPos.Y.ToInt( ) ) , new Rectangle( 0 , 0 , Bottom.Width - Main.LocalPlayer.HeldItem.GetGlobalItem<ShadowKillerCounter>( ).TheShoot * 46 , Bottom.Height ) , Color.White );
                }
                ModContent.GetInstance<ShadowKillerUI>( ).ShadowKillerUIEnable = false;
            }
            return true;
        }
    }
    public class ShadowKillerLoot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( npc.SpawnedFromStatue )
                {
                    return;
                }
                if ( !Main.LocalPlayer.HasItem( ModContent.ItemType<ShadowKiller>( ) ) )
                {
                    if ( Main.rand.Next( 1 , 3 ) == 2 && npc.type == NPCID.SkeletronHead )
                    {
                        int ItemWhoAml = Item.NewItem(null, npc.Center , ModContent.ItemType<ShadowKiller>( ) ); // TODO: try to find source if it doesn't work ~Setnour6
                    }
                }
            }
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class ShadowKillerUI : ModSystem
    {
        public bool ShadowKillerUIEnable = false;

        public override void PreUpdateEntities( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( Main.LocalPlayer.delayUseItem == false && Main.LocalPlayer.HeldItem.type == ModContent.ItemType<ShadowKiller>( ) )
                    ShadowKillerUIEnable = true;
            }
            base.PreUpdateEntities( );
        }

        public override void ModifyInterfaceLayers( List<GameInterfaceLayer> layers )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                layers.Insert( layers.FindIndex( a => a.Name == "Vanilla: Entity Health Bars" ) , new ShadowKillerDrawLayer( ) );
            }
            base.ModifyInterfaceLayers( layers );
        }
    }
}