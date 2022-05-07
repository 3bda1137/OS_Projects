namespace MINI_FILE_SYSTEM
{
    public static class ProgramBase
    {
        private static Directory current;

        internal static Directory Current { get => current; set => current = value; }
    }
}