using EternalResolve.Common.Contents.Entities.Items.Runes;
using EternalResolve.Common.Contents.Entities.Items.Stabbings;
using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items
{
    public abstract class ERItem : ModItem
    {
        public GameCulture Chinese = GameCulture.FromCultureName( GameCulture.CultureName.Chinese );

        public GameCulture English = GameCulture.FromCultureName( GameCulture.CultureName.English );

        public void ToItem( int rare )
        {
            Item.rare = rare;
            Item.maxStack = 999;
            Item.width = 32;
            Item.height = 32;
        }
        public void ToRune( int rare )
        {
            ToItem( 4 );
            Item.scale = 0.1f;
            Item.GetGlobalItem<RuneItem>( ).IsRune = true;
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
        }
        public void ToAccessory( int rare )
        {
            ToItem( rare );
            Item.maxStack = 1;
            Item.accessory = true;
        }
        public void ToBow( int rare )
        {
            ToItem( rare );
            Item.DamageType = DamageClass.Ranged;
            Item.damage = rare * 5;
            Item.crit = 4 + rare * 5;
            Item.useTime = 23 - rare;
            Item.useAnimation = 23 - rare;
            Item.knockBack = 0.6f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 12;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.maxStack = 1;
        }
        public void ToSword( int rare )
        {
            ToItem( rare );
            Item.DamageType = DamageClass.Melee;
            Item.damage = rare * 5;
            Item.crit = 4 + rare;
            Item.useTime = 19 - rare;
            Item.useAnimation = 19 - rare;
            Item.knockBack = 5f + ( rare * 0.5f );
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.maxStack = 1;
        }
        public void ToPick( int rare )
        {
            ToItem( rare );
            ToSword( rare );
            Item.damage = rare * 3;
            Item.pick = rare * 5 + 35;
        }
        public void ToStabbing( int rare )
        {
            ToSword( rare );
            Item.noUseGraphic = false;
            Item.channel = true;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<StabbingProjectile>( );
            Item.shootSpeed = 16f;
            Item.value = Item.sellPrice( 0 , 2 );
            Item.useStyle = 13;
            Item.useAnimation = 24;
            Item.useTime = 24;
        }
        public void ToRod( int rare )
        {
            ( (ERItem) Item.ModItem ).ToSword( rare );
            Item.damage = rare * 7;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.mana = Item.rare;
            Item.shoot = ProjectileID.DiamondBolt;
            Item.shootSpeed = 10 + Item.rare;
            Item.useTime = Item.useAnimation;
            Item.UseSound = SoundID.Item43;
        }

        public void ToGun( int rare )
        {
            ToItem( rare );
            Item.noMelee = true;
            Item.DamageType = DamageClass.Ranged;
            Item.damage = rare * 4;
            Item.crit = 4 + rare * 3;
            Item.useTime = 16 - rare;
            Item.useAnimation = 16 - rare;
            Item.knockBack = 0.4f;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item40;
            Item.autoReuse = true;
            Item.maxStack = 1;
        }
        public void ToYoyo( int rare , int yoyo )
        {
            Item.rare = rare;
            Item.damage = Item.rare * 5;
            Item.width = 24;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.shoot = yoyo;
            Item.useAnimation = 12;
            Item.useTime = 12;
            Item.shootSpeed = (float) ( Item.rare * 7 );
            Item.knockBack = 4f;
            ItemID.Sets.Yoyo[ Item.type ] = true;
            ItemID.Sets.GamepadExtraRange[ Item.type ] = 15;
            ItemID.Sets.GamepadSmartQuickReach[ Item.type ] = true;
        }
        public void ToBrick( int rare , int createTile )
        {
            ToItem( rare );
            Item.consumable = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 1;
            Item.maxStack = 999;
            Item.createTile = createTile;
        }
    }
}
