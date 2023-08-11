using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Tiles;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TheSkeletronMod.Items.Accessories;
using TheSkeletronMod.Common.DamageClasses;

namespace TheSkeletronMod.Items.Accessories
{
    internal class SkullNecklace : ModItem
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Item>(ItemID.BandofRegeneration);
        public override void SetDefaults()
        {   
            Item.value = 12000;
            Item.rare = 1;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<Bonecursed>()) += 0.05f;
            player.endurance += 0.05f;  
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SkullPendant>(), 1);
            recipe.AddTile(ModContent.TileType<BoneAltar>());
            recipe.Register();
        }

    }
}