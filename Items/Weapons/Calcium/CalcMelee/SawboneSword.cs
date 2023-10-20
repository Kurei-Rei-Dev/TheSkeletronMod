﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Creative;
using TheSkeletronMod.Common.Globals;

namespace TheSkeletronMod.Items.Weapons.Calcium.CalcMelee
{
    internal class SawboneSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.ItemDefaultMeleeShootProjectile(54, 64, 50, 7f, 25, 25, -1, ModContent.ProjectileType<SawboneSwordP>(), 1, true);
            Item.DamageType = DamageClass.Melee;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(0, 10, 10);
            if (Item.TryGetGlobalItem(out ImprovedSwingSword meleeItem))
            {
                meleeItem.ArrayOfAttack =
                    new CustomAttack[]
                    {
                        new CustomAttack(CustomUseStyle.PokeAttack, true),
                        new CustomAttack(CustomUseStyle.PokeAttack, false)
                    };
                meleeItem.ItemSwingDegree = 150;
            }
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 direction = new Vector2(70 * player.direction, 0);
            Vector2 randomizePosition = new Vector2(Main.rand.Next(-30, 30), 0);
            for (int i = 0; i < 5; i++)
            {
                if (player.altFunctionUse == 2 && player.ownedProjectileCounts[ModContent.ProjectileType<SawboneSwordP>()] < 1)
                {
                    Projectile.NewProjectile(Item.GetSource_FromThis(), position, Vector2.Zero, ModContent.ProjectileType<SawboneSwordSpawnSpikeP>(), damage, knockback, player.whoAmI, i, 2);
                }
                else if (player.altFunctionUse != 2)
                {
                    Projectile.NewProjectile(Item.GetSource_FromThis(), randomizePosition + position + direction * (i + 1) - new Vector2(0, 20)
                        , Vector2.Zero, ModContent.ProjectileType<SawboneSwordSpawnSpikeP>(), damage, knockback, player.whoAmI, i, player.direction);
                }
            }
            return false;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Vector2 hitboxCenter = new Vector2(hitbox.X, hitbox.Y);
            int dust = Dust.NewDust(hitboxCenter, hitbox.Width, hitbox.Height, DustID.Blood, 0, 0, 0, Color.Purple, Main.rand.NextFloat(1.25f, 1.75f));
            Main.dust[dust].noGravity = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.CrimtaneBar, 12);
                recipe.AddIngredient(ItemID.Bone, 20);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();

            Recipe recipe2 = CreateRecipe();
                recipe2.AddIngredient(ItemID.DemoniteBar, 12);
                recipe2.AddIngredient(ItemID.Bone, 20);
                recipe2.AddTile(TileID.Anvils);
                recipe2.Register();
        }
    }
    public class SawboneSwordSpawnSpikeP : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<SawboneSword>();
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.penetrate = -1;
            Projectile.hide = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        int timer = 0;
        bool isAlreadyInTile = false;
        public override bool PreAI()
        {
            if (timer == 0 && Projectile.ai[1] == 2)
            {
                Projectile.Kill();
                return false;
            }
            return true;
        }
        public override void AI()
        {
            if (timer >= 20 + 10 * Projectile.ai[0])
            {
                Projectile.tileCollide = true;
                Projectile.velocity.Y = 40;
            }
            else
            {
                if (Collision.SolidTiles(Projectile.position, Projectile.width, Projectile.height))
                {
                    isAlreadyInTile = true;
                }

                timer++;
            }
        }

        public override void Kill(int timeLeft)
        {
            if (timer < 20)
            {
                Player player = Main.player[Projectile.owner];
                Vector2 newPos = player.Center + ((Main.MouseWorld - player.Center).SafeNormalize(Vector2.Zero) * -75f).Vector2Evenly(5, 180, (int)Projectile.ai[0]);
                for (int i = 0; i < 40; i++)
                {
                    int dust = Dust.NewDust(newPos, 0, 0, DustID.Blood, 0, 0, 0, default, Main.rand.NextFloat(1.3f, 2.35f));
                    Main.dust[dust].velocity = Main.rand.NextVector2Circular(10, 10);
                    Main.dust[dust].noGravity = true;
                    int dust2 = Dust.NewDust(newPos, 0, 0, DustID.Bone, 0, 0, 0, default, Main.rand.NextFloat(1.3f, 2.35f));
                    Main.dust[dust2].velocity = Main.rand.NextVector2Circular(10, 10);
                    Main.dust[dust2].noGravity = true;
                }

                Projectile.NewProjectile(Projectile.GetSource_FromThis(),
                    newPos,
                    Vector2.Zero, ModContent.ProjectileType<SawboneSwordP>(),
                    Projectile.damage, 0f, Projectile.owner, Projectile.ai[0], Projectile.ai[1]);
                return;
            }

            if (isAlreadyInTile)
            {
                return;
            }

            for (int i = 0; i < 40; i++)
            {
                int dust = Dust.NewDust(Projectile.Center + new Vector2(-2, 20), 0, 0, DustID.Blood, 0, 0, 0, Color.Purple, Main.rand.NextFloat(1.3f, 2.35f));
                Main.dust[dust].noGravity = true;
                Vector2 dustVelocity = Main.rand.NextVector2Unit(-MathHelper.PiOver2 - MathHelper.PiOver4, MathHelper.PiOver4 * (Main.rand.NextFloat(.5f, .7f) + i * .03f)) * Main.rand.Next(3, 15);
                dustVelocity.X *= Projectile.ai[1];
                Main.dust[dust].velocity = dustVelocity;
            }

            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.Center + new Vector2(0, 20 /*+ (25 * Projectile.ai[0])*/),
                new Vector2(0, -2f /*+ (-2 * .25f * Projectile.ai[0])*/ ),
                ModContent.ProjectileType<SawboneSwordP>(),
                Projectile.damage, 0f, Projectile.owner, Projectile.ai[0], Projectile.ai[1]
                );
        }
    }

    public class SawboneSwordP : ModProjectile
    {
        public override string Texture => SkeletronUtils.GetTheSameTextureAsEntity<SawboneSword>();
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.DontAttachHideToAlpha[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 70;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 100;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
            Projectile.hide = Projectile.ai[1] != 2;
            DrawOffsetX = -10;
        }

        int timer = -1;
        Vector2 DirectionTo;
        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            if (Projectile.ai[1] != 2)
            {
                behindNPCsAndTiles.Add(index);
            }
        }

        public override void AI()
        {
            int dust = -1;
            if (Projectile.ai[1] == 2)
            {
                for (int i = 0; i < Projectile.velocity.Length(); i++)
                {
                    if (Main.rand.NextBool(20))
                    {
                        dust = Dust.NewDust(Projectile.Center + Main.rand.NextVector2Circular(20, 10), 0, 0, DustID.Blood, 0, 0, 0, default, Main.rand.NextFloat(1.25f, 2.1f));
                        Main.dust[dust].noGravity = true;
                    }
                }
                FlyingSwordAttackAI();
            }
            else
            {
                dust = Dust.NewDust(Projectile.Center + Main.rand.NextVector2Circular(20, 10), 0, 0, DustID.Blood, 0, 0, 0, Color.Purple, Main.rand.NextFloat(1.25f, 2.1f));
                Main.dust[dust].noGravity = true;
                Main.dust[dust].fadeIn = 1.5f;
                Projectile.velocity -= Projectile.velocity * .097f;
                Projectile.spriteDirection = directionTo;
            }
        }

        int firstframe = 0;
        int directionTo = 1;
        public override bool PreAI()
        {
            if (Projectile.ai[1] == 2)
            {
                if (Projectile.timeLeft == 100)
                {
                    Projectile.width = Projectile.height = 35;
                    DirectionTo = (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero);
                    if (DirectionTo.X > 0)
                    {
                        DrawOriginOffsetX = 10;
                    }
                    else
                    {
                        DrawOriginOffsetY = -20;
                    }
                    Projectile.hide = false;
                }
                return true;
            }
            if (Projectile.timeLeft == 100)
            {
                directionTo = (int)Projectile.ai[1];
                //This is scaling projectile size base on Projectile.ai[0], but it is so stupid that it somehow fuck the projectile position, i probably know why, but too lazy to fix it
                //Projectile.scale += Projectile.ai[0] * .25f;
                //Projectile.Hitbox = new Rectangle(
                //    (int)(Projectile.position.X + (Projectile.width - Projectile.scale * Projectile.width)),
                //    (int)(Projectile.position.Y + (Projectile.height - Projectile.scale * Projectile.height) * 2f),
                //    (int)(Projectile.width * Projectile.scale),
                //    (int)(Projectile.height * Projectile.scale));
                //DrawOffsetX = (int)(10 * Projectile.scale) * directionTo;
            }

            float pi = directionTo == 1 ? MathHelper.PiOver4 : MathHelper.PiOver2 + MathHelper.PiOver4;
            Projectile.rotation = Projectile.velocity.ToRotation() + pi;
            return base.PreAI();
        }

        private void FlyingSwordAttackAI()
        {
            float AdditionalRotationValue = DirectionTo.X > 0 ? MathHelper.PiOver4 : MathHelper.PiOver2 + MathHelper.PiOver4;
            Projectile.rotation = DirectionTo.ToRotation() + AdditionalRotationValue;
            Projectile.spriteDirection = DirectionTo.X > 0 ? 1 : -1;
            timer++;
            if (timer < (Projectile.ai[0] + 5) * 5)
            {
                Projectile.velocity += (Projectile.rotation + (DirectionTo.X > 0 ? MathHelper.PiOver4 + MathHelper.PiOver2 : MathHelper.PiOver4)).ToRotationVector2() * .1f;
                return;
            }
            int timeleft = Projectile.timeLeft + (int)(Projectile.ai[0] + 5) * 5;
            if (Projectile.timeLeft != timeleft && firstframe == 0)
            {
                Projectile.tileCollide = true;
                Projectile.penetrate = 3;
                Projectile.timeLeft = timeleft;
                firstframe++;
            }
            //Projectile.Hitbox = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, (int)(Projectile.position.X + 30), (int)(Projectile.position.Y + 30));
            Projectile.velocity += DirectionTo;
            Projectile.velocity = Projectile.velocity.LimitingVelocity(20);
        }

        public override void Kill(int timeLeft)
        {
            Vector2 pos = new Vector2(0, 60);
            if (Projectile.ai[1] == 2)
            {
                for (int i = 0; i < 15; i++)
                {
                    pos = Main.rand.NextVector2Circular(20, 20);
                    Dust.NewDust(Projectile.Center + pos, 0, 0, DustID.Blood, 0, .5f, 0, Color.Purple, Main.rand.NextFloat(1.25f, 1.75f));
                    Dust.NewDust(Projectile.Center + pos, 0, 0, DustID.Bone, 0, .5f, 0, default, Main.rand.NextFloat(1f, 1.25f));
                }
                return;
            }
            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(Projectile.Center - pos, 30, 60, DustID.Blood, 0, .5f, 0, Color.Purple, Main.rand.NextFloat(1.25f, 1.75f));
                Dust.NewDust(Projectile.Center - pos, 30, 60, DustID.Bone, 0, .5f, 0, default, Main.rand.NextFloat(1f, 1.25f));
            }
        }
    }
}