using RimWorld;
using Verse;
using System.Collections.Generic;

namespace RimPiece
{
    public class DevilFruitTracker : GameComponent
    {
        public HashSet<string> registeredFruits = new HashSet<string>();

        public DevilFruitTracker(Game game) { }

        public void RegisterFruit(string fruitDefName)
        {
            registeredFruits.Add(fruitDefName);
        }

        public bool IsFruitRegistered(string fruitDefName)
        {
            return registeredFruits.Contains(fruitDefName);
        }

        public void Clear()
        {
            registeredFruits.Clear();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref registeredFruits, "registeredFruits", LookMode.Value);
        }
    }
}