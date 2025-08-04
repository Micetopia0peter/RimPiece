using Verse;
using RimWorld;

namespace RimPiece
{
    public class CompProperties_AbilityHakiXP : CompProperties_AbilityEffect
    {
        public float xpAmount = 5f;

        public CompProperties_AbilityHakiXP()
        {
            compClass = typeof(CompAbilityEffect_HakiXP);
        }
    }

    public class CompAbilityEffect_HakiXP : CompAbilityEffect
    {
        public CompProperties_AbilityHakiXP Props => (CompProperties_AbilityHakiXP)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);

            if (parent.pawn is Pawn caster)
            {
                var comp = caster.GetComp<CompHakiUser>();
                if (comp?.HasHakiPotential == true)
                {
                    comp.GainHakiXP(Props.xpAmount);
                }
            }
        }
    }
}