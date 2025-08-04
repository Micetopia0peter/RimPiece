using RimWorld;
using System;
using UnityEngine;
using Verse;
using System.Linq;

namespace RimPiece
{
    public class CompProperties_HakiUser : CompProperties
    {
        public CompProperties_HakiUser()
        {
            this.compClass = typeof(CompHakiUser);
        }
    }

    public class CompHakiUser : ThingComp
    {
        private float hakiXP = 0f;
        private int hakiTier = 0;

        private const int MaxTier = 3;
        private static readonly float[] TierThresholds = { 100f, 300f, 600f };

        public float CurrentXP => hakiXP;
        public int CurrentTier => hakiTier;

        public float XPToNextTier => hakiTier < MaxTier ? TierThresholds[hakiTier] : TierThresholds.Last();
        public float PercentToNextTier => hakiTier >= MaxTier ? 100f : Mathf.Clamp01(hakiXP / XPToNextTier) * 100f;

        public override void PostExposeData()
        {
            Scribe_Values.Look(ref hakiXP, "hakiXP", 0f);
            Scribe_Values.Look(ref hakiTier, "hakiTier", 0);
        }

        public void GainHakiXP(float amount)
        {
            hakiXP += amount;
            TryLevelUpHaki();
        }

        public void TryLevelUpHaki()
        {
            while (hakiTier < MaxTier && hakiXP >= TierThresholds[hakiTier])
            {
                hakiTier++;
                Messages.Message($"Haki Tier increased to {hakiTier}!", parent, MessageTypeDefOf.PositiveEvent);
                UnlockTierAbilities(hakiTier);
            }
        }

        private void UnlockTierAbilities(int tier)
        {
            // Hook in XML abilities here later
            switch (tier)
            {
                case 1:
                    // Armament unlock
                    break;
                case 2:
                    // Observation unlock
                    break;
                case 3:
                    // Advanced Haki
                    break;
            }
        }

        public override string CompInspectStringExtra()
        {
            return $"Haki XP: {hakiXP:F1} / Tier: {hakiTier}";
        }
    }
}