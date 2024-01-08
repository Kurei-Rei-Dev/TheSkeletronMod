﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using TheSkeletronMod.Common.DamageClasses;
using TheSkeletronMod.Common.Utils;
using TheSkeletronMod.Content.Items.Materials;
using TheSkeletronMod.Content.Items.Materials.OreBones;
using TheSkeletronMod.Content.Items.Placeables.Bars;
using TheSkeletronMod.Content.Projectiles.Calcprojs.CalcMeleeproj;
using TheSkeletronMod.Content.Tiles;

namespace TheSkeletronMod.Content.Items.Weapons.Calcium.CalcMelee
{
    public class SkeletalReaper : ModItem
    {
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootProjectile(54, 33, 130, 7f, 400, 400, ItemUseStyleID.Swing, ModContent.ProjectileType<SkeletalReaperP>(), 10, true);
            Item.DamageType = ModContent.GetInstance<Bonecursed>();
            Item.UseSound = SoundID.Item1;
            Item.useTime = 30;
            Item.useAnimation = 30;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), ModContent.ProjectileType<SkeletalReaperProjectile>(), damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override bool MeleePrefix()
        {
            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe() // iron, gold, and demonite bone
                .AddIngredient(ModContent.ItemType<IronBone>(),6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<GoldBone>(),6)
                .AddIngredient(ModContent.ItemType<DemoniteBone>(),6)
                .AddIngredient(ModContent.ItemType<AncientBone>(),25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(),1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // lead, gold, and demonite bone
                .AddIngredient(ModContent.ItemType<LeadBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<GoldBone>(), 6)
                .AddIngredient(ModContent.ItemType<DemoniteBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // iron, platinum, and demonite bone
                .AddIngredient(ModContent.ItemType<IronBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 6)
                .AddIngredient(ModContent.ItemType<DemoniteBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // lead, platinum, and demonite bone
                .AddIngredient(ModContent.ItemType<LeadBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 6)
                .AddIngredient(ModContent.ItemType<DemoniteBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();




            CreateRecipe() // iron, gold, and Crimtane bone
                .AddIngredient(ModContent.ItemType<IronBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<GoldBone>(), 6)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // lead, gold, and Crimtane bone
                .AddIngredient(ModContent.ItemType<LeadBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<GoldBone>(), 6)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // iron, platinum, and Crimtane bone
                .AddIngredient(ModContent.ItemType<IronBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 6)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
            CreateRecipe() // lead, platinum, and Crimtane bone
                .AddIngredient(ModContent.ItemType<LeadBone>(), 6)
                .AddIngredient(ModContent.ItemType<CalciumBar>(), 6)
                .AddIngredient(ModContent.ItemType<PlatinumBone>(), 6)
                .AddIngredient(ModContent.ItemType<CrimtaneBone>(), 6)
                .AddIngredient(ModContent.ItemType<AncientBone>(), 25)
                .AddIngredient(ModContent.ItemType<BoneScythe>(), 1)
                .AddTile(ModContent.TileType<BoneAltar>())
                .Register();
        }
    }
    public class SkeletalReaperProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.AllowsContactDamageFromJellyfish[Type] = true;
            Main.projFrames[Type] = 4;
        }
        public override void SetDefaults()
        {
            // The width and height don't really matter here because we have custom collision.
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 4;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.ownerHitCheckDistance = 300f;
            Projectile.usesOwnerMeleeHitCD = true; 
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            // In our item, we spawn the projectile with the direction, max time, and scale
            // Projectile.ai[0] == direction
            // Projectile.ai[1] == max time
            // Projectile.ai[2] == scale
            // Projectile.localAI[0] == current time

            // Terra Blade makes an extra sound when spawning.
            // if (Projectile.localAI[0] == 0f) {
            // 	SoundEngine.PlaySound(SoundID.Item60 with { Volume = 0.65f }, Projectile.position);
            // }

            Projectile.localAI[0]++; // Current time that the projectile has been alive.
            Player player = Main.player[Projectile.owner];
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float direction = Projectile.ai[0];
            float velocityRotation = Projectile.velocity.ToRotation();
            float adjustedRotation = MathHelper.Pi * direction * percentageOfLife + velocityRotation + direction * MathHelper.Pi + player.fullRotation;
            Projectile.rotation = adjustedRotation; // Set the rotation to our to the new rotation we calculated.

            float scaleMulti = 0.6f; // Excalibur, Terra Blade, and The Horseman's Blade is 0.6f; True Excalibur is 1f; default is 0.2f 
            float scaleAdder = 1f; // Excalibur, Terra Blade, and The Horseman's Blade is 1f; True Excalibur is 1.2f; default is 1f 

            Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) - Projectile.velocity;
            Projectile.scale = scaleAdder + percentageOfLife * scaleMulti;


            float dustRotation = Projectile.rotation + Main.rand.NextFloatDirection() * MathHelper.PiOver2 * 0.7f;
            Vector2 dustPosition = Projectile.Center + dustRotation.ToRotationVector2() * 84f * Projectile.scale;
            Vector2 dustVelocity = (dustRotation + Projectile.ai[0] * MathHelper.PiOver2).ToRotationVector2();
            if (Main.rand.NextFloat() * 2f < Projectile.Opacity)
            {
                Color dustColor = Color.Lerp(Color.MediumPurple, Color.White, Main.rand.NextFloat() * 0.3f);
                Dust coloredDust = Dust.NewDustPerfect(Projectile.Center + dustRotation.ToRotationVector2() * (Main.rand.NextFloat() * 80f * Projectile.scale + 20f * Projectile.scale), DustID.FireworksRGB, dustVelocity * 1f, 100, dustColor, 0.4f);
                coloredDust.fadeIn = 0.4f + Main.rand.NextFloat() * 0.15f;
                coloredDust.noGravity = true;
            }

            if (Main.rand.NextFloat() * 1.5f < Projectile.Opacity)
            {
                Dust.NewDustPerfect(dustPosition, DustID.TintableDustLighted, dustVelocity, 100, Color.MediumPurple * Projectile.Opacity, 1.2f * Projectile.Opacity);
            }

            Projectile.scale *= Projectile.ai[2];
            if (Projectile.localAI[0] >= Projectile.ai[1])
            {
                Projectile.Kill();
            }

            for (float i = -MathHelper.PiOver4; i <= MathHelper.PiOver4; i += MathHelper.PiOver2)
            {
                Rectangle rectangle = Utils.CenteredRectangle(Projectile.Center + (Projectile.rotation + i).ToRotationVector2() * 70f * Projectile.scale, new Vector2(60f * Projectile.scale, 60f * Projectile.scale));
                Projectile.EmitEnchantmentVisualsAt(rectangle.TopLeft(), rectangle.Width, rectangle.Height);
            }
        }

        // Here is where we have our custom collision.
        // This collision will only run if the projectile is within range of target with the range being Projectile.ownerHitCheckDistance
        // Or if the projectile hasn't already hit all of the targets it can with Projectile.penetrate
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            // This is how large the circumference is, aka how big the range is. Vanilla uses 94f to match it to the size of the texture.
            float coneLength = 94f * Projectile.scale;
            // This number affects how much the start and end of the collision will be rotated.
            // Bigger Pi numbers will rotate the collision counter clockwise.
            // Smaller Pi numbers will rotate the collision clockwise.
            // (Projectile.ai[0] is the direction)
            float collisionRotation = MathHelper.Pi * 2f / 25f * Projectile.ai[0];
            float maximumAngle = MathHelper.PiOver4; // The maximumAngle is used to limit the rotation to create a dead zone.
            float coneRotation = Projectile.rotation + collisionRotation;

            // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
            // Dust.NewDustPerfect(Projectile.Center + coneRotation.ToRotationVector2() * coneLength, DustID.Pixie, Vector2.Zero);
            // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(maximumAngle) * Projectile.ai[0], (float)Math.Sin(maximumAngle)) * 5f); // Assumes collisionRotation was not changed

            // First, we check to see if our first cone intersects the target.
            if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation, maximumAngle))
            {
                return true;
            }

            // The first cone isn't the entire swinging arc, though, so we need to check a second cone for the back of the arc.
            float backOfTheSwing = Utils.Remap(Projectile.localAI[0], Projectile.ai[1] * 0.3f, Projectile.ai[1] * 0.5f, 1f, 0f);
            if (backOfTheSwing > 0f)
            {
                float coneRotation2 = coneRotation - MathHelper.PiOver4 * Projectile.ai[0] * backOfTheSwing;

                // Uncomment this line for a visual representation of the cone. The dusts are not perfect, but it gives a general idea.
                // Dust.NewDustPerfect(Projectile.Center + coneRotation2.ToRotationVector2() * coneLength, DustID.Enchanted_Pink, Vector2.Zero);
                // Dust.NewDustPerfect(Projectile.Center, DustID.BlueFairy, new Vector2((float)Math.Cos(backOfTheSwing) * -Projectile.ai[0], (float)Math.Sin(backOfTheSwing)) * 5f); // Assumes collisionRotation was not changed

                if (targetHitbox.IntersectsConeSlowMoreAccurate(Projectile.Center, coneLength, coneRotation2, maximumAngle))
                {
                    return true;
                }
            }

            return false;
        }

        public override void CutTiles()
        {
            // Here we calculate where the projectile can destroy grass, pots, Queen Bee Larva, etc.
            Vector2 starting = (Projectile.rotation - MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            Vector2 ending = (Projectile.rotation + MathHelper.PiOver4).ToRotationVector2() * 60f * Projectile.scale;
            float width = 60f * Projectile.scale;
            Utils.PlotTileLine(Projectile.Center + starting, Projectile.Center + ending, width, DelegateMethods.CutTiles);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Vanilla has several particles that can easily be used anywhere.
            // The particles from the Particle Orchestra are predefined by vanilla and most can not be customized that much.
            // Use auto complete to see the other ParticleOrchestraType types there are.
            // Here we are spawning the Excalibur particle randomly inside of the target's hitbox.
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);

            // You could also spawn dusts at the enemy position. Here is simple an example:
            // Dust.NewDust(Main.rand.NextVector2FromRectangle(target.Hitbox), 0, 0, ModContent.DustType<Content.Dusts.Sparkle>());

            // Set the target's hit direction to away from the player so the knockback is in the correct direction.
            hit.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                Projectile.owner);

            info.HitDirection = (Main.player[Projectile.owner].Center.X < target.Center.X) ? 1 : (-1);
        }

        // Taken from Main.DrawProj_Excalibur()
        // Look at the source code for the other sword types.
        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 position = Projectile.Center - Main.screenPosition;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = texture.Frame(1, 4); // The sourceRectangle says which frame to use.
            Vector2 origin = sourceRectangle.Size() / 2f;
            float scale = Projectile.scale * 1.1f;
            SpriteEffects spriteEffects = ((!(Projectile.ai[0] >= 0f)) ? SpriteEffects.FlipVertically : SpriteEffects.None); // Flip the sprite based on the direction it is facing.
            float percentageOfLife = Projectile.localAI[0] / Projectile.ai[1]; // The current time over the max time.
            float lerpTime = Utils.Remap(percentageOfLife, 0f, 0.6f, 0f, 1f) * Utils.Remap(percentageOfLife, 0.6f, 1f, 1f, 0f);
            float lightingColor = Lighting.GetColor(Projectile.Center.ToTileCoordinates()).ToVector3().Length() / (float)Math.Sqrt(3.0);
            lightingColor = Utils.Remap(lightingColor, 0.2f, 1f, 0f, 1f);

            Color backDarkColor = new Color(160, 60, 180); // Original Excalibur color: Color(180, 160, 60)
            Color middleMediumColor = new Color(255, 80, 255); // Original Excalibur color: Color(255, 255, 80)
            Color frontLightColor = new Color(240, 150, 255); // Original Excalibur color: Color(255, 240, 150)

            Color whiteTimesLerpTime = Color.White * lerpTime * 0.5f;
            whiteTimesLerpTime.A = (byte)(whiteTimesLerpTime.A * (1f - lightingColor));
            Color faintLightingColor = whiteTimesLerpTime * lightingColor * 0.5f;
            faintLightingColor.G = (byte)(faintLightingColor.G * lightingColor);
            faintLightingColor.B = (byte)(faintLightingColor.R * (0.25f + lightingColor * 0.75f));

            // Back part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, backDarkColor * lightingColor * lerpTime, Projectile.rotation + Projectile.ai[0] * MathHelper.PiOver4 * -1f * (1f - percentageOfLife), origin, scale, spriteEffects, 0f);
            // Very faint part affected by the light color
            Main.EntitySpriteDraw(texture, position, sourceRectangle, faintLightingColor * 0.15f, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Middle part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, middleMediumColor * lightingColor * lerpTime * 0.3f, Projectile.rotation, origin, scale, spriteEffects, 0f);
            // Front part
            Main.EntitySpriteDraw(texture, position, sourceRectangle, frontLightColor * lightingColor * lerpTime * 0.5f, Projectile.rotation, origin, scale * 0.975f, spriteEffects, 0f);
            // Thin top line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.6f * lerpTime, Projectile.rotation + Projectile.ai[0] * 0.01f, origin, scale, spriteEffects, 0f);
            // Thin middle line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.5f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.05f, origin, scale * 0.8f, spriteEffects, 0f);
            // Thin bottom line (final frame)
            Main.EntitySpriteDraw(texture, position, texture.Frame(1, 4, 0, 3), Color.White * 0.4f * lerpTime, Projectile.rotation + Projectile.ai[0] * -0.1f, origin, scale * 0.6f, spriteEffects, 0f);

            // This draws some sparkles around the circumference of the swing.
            for (float i = 0f; i < 8f; i += 1f)
            {
                float edgeRotation = Projectile.rotation + Projectile.ai[0] * i * (MathHelper.Pi * -2f) * 0.025f + Utils.Remap(percentageOfLife, 0f, 1f, 0f, MathHelper.PiOver4) * Projectile.ai[0];
                Vector2 drawpos = position + edgeRotation.ToRotationVector2() * ((float)texture.Width * 0.5f - 6f) * scale;
                DrawPrettyStarSparkle(Projectile.Opacity, SpriteEffects.None, drawpos, new Color(255, 255, 255, 0) * lerpTime * (i / 9f), middleMediumColor, percentageOfLife, 0f, 0.5f, 0.5f, 1f, edgeRotation, new Vector2(0f, Utils.Remap(percentageOfLife, 0f, 1f, 3f, 0f)) * scale, Vector2.One * scale);
            }

            // This draws a large star sparkle at the front of the projectile.
            Vector2 drawpos2 = position + (Projectile.rotation + Utils.Remap(percentageOfLife, 0f, 1f, 0f, MathHelper.PiOver4) * Projectile.ai[0]).ToRotationVector2() * ((float)texture.Width * 0.5f - 4f) * scale;
            DrawPrettyStarSparkle(Projectile.Opacity, SpriteEffects.None, drawpos2, new Color(255, 255, 255, 0) * lerpTime * 0.5f, middleMediumColor, percentageOfLife, 0f, 0.5f, 0.5f, 1f, 0f, new Vector2(2f, Utils.Remap(percentageOfLife, 0f, 1f, 4f, 1f)) * scale, Vector2.One * scale);

            // Uncomment this line for a visual representation of the projectile's size.
            // Main.EntitySpriteDraw(TextureAssets.MagicPixel.Value, position, sourceRectangle, Color.Orange * 0.75f, 0f, origin, scale, spriteEffects);

            return false;
        }

        // Copied from Main.DrawPrettyStarSparkle() which is private
        private static void DrawPrettyStarSparkle(float opacity, SpriteEffects dir, Vector2 drawpos, Color drawColor, Color shineColor, float flareCounter, float fadeInStart, float fadeInEnd, float fadeOutStart, float fadeOutEnd, float rotation, Vector2 scale, Vector2 fatness)
        {
            Texture2D sparkleTexture = TextureAssets.Extra[98].Value;
            Color bigColor = shineColor * opacity * 0.5f;
            bigColor.A = 0;
            Vector2 origin = sparkleTexture.Size() / 2f;
            Color smallColor = drawColor * 0.5f;
            float lerpValue = Utils.GetLerpValue(fadeInStart, fadeInEnd, flareCounter, clamped: true) * Utils.GetLerpValue(fadeOutEnd, fadeOutStart, flareCounter, clamped: true);
            Vector2 scaleLeftRight = new Vector2(fatness.X * 0.5f, scale.X) * lerpValue;
            Vector2 scaleUpDown = new Vector2(fatness.Y * 0.5f, scale.Y) * lerpValue;
            bigColor *= lerpValue;
            smallColor *= lerpValue;
            // Bright, large part
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, bigColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, bigColor, 0f + rotation, origin, scaleUpDown, dir);
            // Dim, small part
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, smallColor, MathHelper.PiOver2 + rotation, origin, scaleLeftRight * 0.6f, dir);
            Main.EntitySpriteDraw(sparkleTexture, drawpos, null, smallColor, 0f + rotation, origin, scaleUpDown * 0.6f, dir);
        }
        
        
    }
}
