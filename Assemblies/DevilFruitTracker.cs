using Verse;
using System.Collections.Generic;

namespace DevilFruits
{
    [StaticConstructorOnStartup]
    public static class DevilFruitTracker
    {
        public static HashSet<string> existingFruits = new HashSet<string>();

        static DevilFruitTracker()
        {
            Log.Message("[DevilFruits] Tracker initialized.");
        }

        public static bool TryRegisterFruit(string defName)
        {
            if (existingFruits.Contains(defName))
            {
                return false; // Already taken
            }

            existingFruits.Add(defName);
            return true;
        }
    }
}