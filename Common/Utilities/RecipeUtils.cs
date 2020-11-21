﻿using Terraria;
using Terraria.Localization;

namespace Terrexpansion.Common.Utilities
{
    public static class RecipeUtils
    {
        /// <summary>
        /// Combination of <c>TryGetItem</c> and <c>RemoveIngredient</c>, all condensed into one method.
        /// </summary>
        public static bool TryRemoveIngredient(this Recipe recipe, int itemType)
        {
            if (recipe.TryGetIngredient(itemType, out Item item))
            {
                return recipe.RemoveIngredient(item); ;
            }

            return false;
        }

        /// <summary>
        /// Creates a recipe group using the specified parameters. Mod name defaults to Terrexpansion.
        /// <para>Returns the created RecipeGroup.</para>
        /// </summary>
        public static RecipeGroup CreateRecipeGroup(string internalName, string displayName, int[] items, string modName = "Terrexpansion")
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + $" {displayName}", items);
            RecipeGroup.RegisterGroup($"{modName}:{internalName}", group);

            return group;
        }
    }
}