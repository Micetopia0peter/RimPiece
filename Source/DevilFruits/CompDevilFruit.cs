using RimWorld;
using Verse;

namespace RimPiece
{
    public class CompDevilFruit : ThingComp
    {
        public CompProperties_DevilFruit Props => (CompProperties_DevilFruit)this.props;

        public override void PostIngested(Pawn ingester)
        {
            base.PostIngested(ingester);

            var tracker = RimPieceUtility.GetTracker();
            string fruitDef = parent.def.defName;

            // Check if fruit already exists in tracker
            if (tracker.IsFruitRegistered(fruitDef))
            {
                Messages.Message("This Devil Fruit has already been consumed in this world.", MessageTypeDefOf.RejectInput, false);
                return;
            }

            // Apply effects (traits, abilities, etc.)
            if (!ingester.story.traits.HasTrait(Props.givenTrait))
            {
                ingester.story.traits.GainTrait(new Trait(Props.givenTrait));
            }

            // Register the fruit
            tracker.RegisterFruit(fruitDef);

            // Optional: Notify player
            Messages.Message($"{ingester.NameShortColored} has eaten the {parent.Label}!", MessageTypeDefOf.PositiveEvent, true);
        }
    }

    public class CompProperties_DevilFruit : CompProperties
    {
        public TraitDef givenTrait;

        public CompProperties_DevilFruit()
        {
            this.compClass = typeof(CompDevilFruit);
        }
    }
}