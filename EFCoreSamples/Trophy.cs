using System.Collections.Generic;

namespace EFCoreSamples
{
    public class Trophy
    {
        public int TrophyId { get; set; }
        public string Name { get; set; }
        public TrophyRarity Rarity { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
