﻿using Terraria;
using Terraria.Localization;
using Terrexpansion.Common.Systems.Players;

namespace Terrexpansion.Common.Utilities
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// This extension method is made specifically for configs. If you're looking for the normal, non-config method, use <c>IsServerHost(this Player player)</c>.
        /// <para>Can be used to check whether or not a player is the host of a server.</para>
        /// <para>Set <c>changeMessageText</c> to <c>true</c> to set the config's message text to <c>Mods.Terrexpansion.NotServerHostError</c>.</para>
        /// </summary>
        /// <param name="player"></param>
        /// <param name="message"></param>
        /// <param name="changeMessageText"></param>
        /// <returns></returns>
        public static bool IsServerHost(this Player player, ref string message)
        {
            if (IsServerHost(player))
            {
                return true;
            }

            message = Language.GetTextValue("Mods.Terrexpansion.NotServerHostError");
            return false;
        }

        /// <summary>
        /// Can be used to check whether or not a player is the host of a server.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsServerHost(this Player player)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                if (Netplay.Clients[i].State == 10 && Main.player[i] == player && Netplay.Clients[i].Socket.GetRemoteAddress().IsLocalHost())
                {
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// Offhand for <c>player.GetModPlayer<Terre</c>
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static TerrePlayer GetTerrePlayer(this Player player) => player.GetModPlayer<TerrePlayer>();
    }
}