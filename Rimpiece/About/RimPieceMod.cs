public class RimPiece : Mod
{
    public RimPieceMod(ModContentPack content) : base(content)
    {
        var harmony = new Harmony("com.rimpiece.haki");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }
}