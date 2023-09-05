using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TheSkeletronMod.Items.Weapons.Calcium;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.CodeAnalysis;

namespace TheSkeletronMod.projectiles.Calcprojs.CalcMageproj
{
    
    public class BloodArrow2 : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetVanillaTexture<Projectile>(ProjectileID.BloodArrow);
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BloodArrow);
            AIType = ProjectileID.BloodArrow;
        }
        public override void AI()
        {
            Dust.NewDustPerfect(Projectile.Center, DustID.Blood);
        }
    }
}