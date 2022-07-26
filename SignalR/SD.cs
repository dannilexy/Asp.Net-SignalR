namespace SignalR
{
    public static class SD
    {
        static SD()
        {
            DealthyHallowRace = new Dictionary<string, int>();
            DealthyHallowRace.Add("wand", 0);
            DealthyHallowRace.Add("cloak", 0);
            DealthyHallowRace.Add("stone", 0);

        }
        public const string Wand = "wand";
        public const string Cloak = "cloak";
        public const string Stone = "stone";

        public static Dictionary<string, int> DealthyHallowRace;
    }
}
