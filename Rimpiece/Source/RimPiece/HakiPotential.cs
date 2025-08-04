using Verse;

namespace RimPiece
{
    public class HakiPotential : IExposable
    {
        public int MaxTier = 3;
        public bool CanUseArmament = true;
        public bool CanUseObservation = true;
        public bool CanUseConqueror = false;
        public float XPModifier = 1f;

        public HakiPotential() { }

        public HakiPotential(int maxTier, bool arm, bool obs, bool conq, float xpMod = 1f)
        {
            MaxTier = maxTier;
            CanUseArmament = arm;
            CanUseObservation = obs;
            CanUseConqueror = conq;
            XPModifier = xpMod;
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref MaxTier, "MaxTier", 3);
            Scribe_Values.Look(ref CanUseArmament, "CanUseArmament", true);
            Scribe_Values.Look(ref CanUseObservation, "CanUseObservation", true);
            Scribe_Values.Look(ref CanUseConqueror, "CanUseConqueror", false);
            Scribe_Values.Look(ref XPModifier, "XPModifier", 1f);
        }
    }
}