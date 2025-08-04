using RimWorld;
using UnityEngine;
using Verse;

namespace RimPiece
{
    public class ITab_Pawn_Haki : ITab
    {
        private Pawn Pawn => SelPawn;

        public ITab_Pawn_Haki()
        {
            this.size = new Vector2(300f, 150f);
            this.labelKey = "RimPiece_HakiTab";
        }

        public override bool IsVisible
        {
            get
            {
                return Pawn != null && Pawn.GetComp<CompHakiUser>() != null;
            }
        }

        protected override void FillTab()
        {
            Rect rect = new Rect(10f, 10f, size.x - 20f, size.y - 20f);
            Widgets.DrawMenuSection(rect);

            var comp = Pawn.GetComp<CompHakiUser>();
            if (comp != null)
            {
                float curXP = comp.CurrentXP;
                int tier = comp.CurrentTier;
                float pct = comp.PercentToNextTier;

                Listing_Standard listing = new Listing_Standard();
                listing.Begin(rect);
                listing.Label($"Current Haki XP: {curXP:0.##}");
                listing.Label($"Current Tier: {tier}");
                listing.Label($"Progress to Next Tier: {pct:0.##}%");
                listing.End();
            }
            else
            {
                Widgets.Label(rect, "No Haki data.");
            }
        }
    }
}