using Verse;

namespace RimPiece
{
    public static class RimPieceUtility
    {
        public static DevilFruitTracker GetTracker()
        {
            return Current.Game.GetComponent<DevilFruitTracker>();
        }
    }
}