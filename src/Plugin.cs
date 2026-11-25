using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace ABUF.ComaProtect
{
    [BepInPlugin(Guid, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string Guid = "abuf.comaprotect";
        public const string PluginName = "Coma Protection";
        public const string PluginVersion = "1.0.1";

        public static ManualLogSource Log;

        /// <summary>昏迷时冻结死亡倒计时（长按 E 放弃仍然有效）。</summary>
        public static ConfigEntry<bool> Enabled;

        private static readonly Harmony Harmony = new Harmony(Guid);

        private void Awake()
        {
            Log = Logger;

            Enabled = Config.Bind(
                "昏迷保护",
                "启用",
                true,
                "倒地昏迷时死亡倒计时不再自然累积。长按 E 主动放弃仍然有效。");

            Harmony.PatchAll();
            Log.LogInfo(PluginName + " " + PluginVersion + " loaded. enabled=" + Enabled.Value);
        }

        private void OnDestroy()
        {
            Harmony.UnpatchSelf();
        }
    }

    /// <summary>
    /// 原版 UpdateVariablesFixed：
    ///   interactIsPressed      -> deathTimer += dt * 0.33f   （长按 E 放弃）
    ///   carrier == null 等条件 -> deathTimer += dt / 60f（或 /10f） （自然倒计时）
    /// 这里在方法结束时恢复数值，但按 E 时不恢复，所以放弃功能保留。
    /// </summary>
    [HarmonyPatch(typeof(Character), "UpdateVariablesFixed")]
    internal static class ComaProtectPatch
    {
        [HarmonyPrefix]
        private static void Prefix(Character __instance, out float __state)
        {
            __state = 0f;
            if (__instance != null && __instance.data != null && __instance.IsLocal)
            {
                __state = __instance.data.deathTimer;
            }
        }

        [HarmonyPostfix]
        private static void Postfix(Character __instance, float __state)
        {
            if (!Plugin.Enabled.Value)
            {
                return;
            }

            if (__instance == null || __instance.data == null || !__instance.IsLocal)
            {
                return;
            }

            if (!__instance.data.fullyPassedOut || __instance.data.carrier != null)
            {
                return;
            }

            if (__instance.input != null && __instance.input.interactIsPressed)
            {
                return;
            }

            __instance.data.deathTimer = Mathf.Max(__state, __instance.data.deathTimer);
            __instance.data.deathTimer = __state;
        }
    }
}
