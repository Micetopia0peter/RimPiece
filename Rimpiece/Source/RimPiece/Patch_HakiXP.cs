using RimWorld;
using Verse;
using HarmonyLib;

namespace RimPiece
{
    [HarmonyPatch(typeof(DamageWorker_AddInjury), "ApplyToPawn")]
    public static class Patch_HakiXP
    {
        [HarmonyPostfix]
        public static void Postfix(DamageWorker_AddInjury __instance, DamageInfo dinfo, Pawn pawn)
        {
            if (pawn?.health?.State != PawnHealthState.Dead)
            {
                var comp = pawn.GetComp<CompHakiUser>();
                if (comp?.HasHakiPotential == true)
                {
                    comp.GainHakiXP(2f);
                }

                if (dinfo.Instigator is Pawn attacker)
                {
                    var atkComp = attacker.GetComp<CompHakiUser>();
                    if (atkComp?.HasHakiPotential == true)
                    {
                        atkComp.GainHakiXP(5f);
                    }
                }
            }
        }
    }
}