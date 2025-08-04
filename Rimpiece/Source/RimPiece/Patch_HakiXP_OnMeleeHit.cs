using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;

namespace RimPiece.HakiSystem
{
    [HarmonyPatch(typeof(DamageWorker_AddInjury), "ApplyToPawn")]
    public static class Patch_HakiXP_OnMeleeHit
    {
        static void Postfix(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn)
        {
            // Safety: Only proceed if attacker exists and is a pawn
            if (dinfo.Instigator is Pawn attackerPawn)
            {
                // Check it's melee damage only
                if (dinfo.Weapon != null && dinfo.Weapon.IsMeleeWeapon)
                {
                    var hakiComp = attackerPawn.TryGetComp<CompHakiUser>();
                    if (hakiComp != null)
                    {
                        // Gain XP for melee hit — you can tune this value
                        hakiComp.GainHakiXP(5f);
                    }
                }
            }
        }
    }
}