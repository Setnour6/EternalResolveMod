using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns
{
    public class CrystalUziRed : CrystalUziGreen
    {
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Ruby , 6 ).
                AddIngredient( ItemID.IllegalGunParts ).
                AddIngredient( ModContent.ItemType<LegalFirearmsParts>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
