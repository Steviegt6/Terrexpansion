﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Terrexpansion.Content.Menus
{
    public abstract class StaticSplashTextMenu : ModMenu
    {
        public string drawText = "";
        public float textScale = 1f;
        public bool textDirection = false;

        public override void OnSelected() => drawText = Terrexpansion.Instance.splashText[Main.rand.Next(Terrexpansion.Instance.splashText.Count)];

        public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor) => false;

        public override void Update(bool isOnTitleScreen)
        {
            if (textScale >= 1.10f)
                textDirection = true;
            else if (textScale <= 0.90f)
                textDirection = false;

            if (textDirection)
                textScale -= 0.0075f;
            else
                textScale += 0.0075f;
        }

        public override void PostDrawLogo(SpriteBatch spriteBatch, Vector2 logoDrawCenter, float logoRotation, float logoScale, Color drawColor)
        {
            spriteBatch.Draw(Logo.Value, new Vector2(Main.screenWidth / 2, 100f), new Rectangle(0, 0, Logo.Width(), Logo.Height()), drawColor, 0f, new Vector2(Logo.Width() * 0.5f, Logo.Height() * 0.5f), 1f, SpriteEffects.None, 0f);

            if (Terrexpansion.Instance.setupContent)
            {
                for (int i = 0; i < 4; i++)
                    spriteBatch.DrawString(FontAssets.DeathText.Value, drawText, new Vector2(Main.screenWidth / 2 + (Logo.Width() / 2), logoDrawCenter.Y * 1.5f) + new Vector2(i == 0 ? 2f : i == 1 ? -2f : 0f, i == 2 ? 2f : i == 3 ? -2f : 0f), new Color(0, 0, 0, 200), MathHelper.ToRadians(-20f), FontAssets.DeathText.Value.MeasureString(drawText) / 2, 0.5f * textScale, SpriteEffects.None, 0f);

                spriteBatch.DrawString(FontAssets.DeathText.Value, drawText, new Vector2(Main.screenWidth / 2 + (Logo.Width() / 2), logoDrawCenter.Y * 1.5f), Main.OurFavoriteColor, MathHelper.ToRadians(-20f), FontAssets.DeathText.Value.MeasureString(drawText) / 2, 0.5f * textScale, SpriteEffects.None, 0f);
            }
        }
    }
}