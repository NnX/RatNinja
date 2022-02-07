using System;
using System.Collections.Generic;

namespace GameEnvironment.Keepers.SaveKeeper
{
    [Serializable]
    public class SaveDataBox {
        public Dictionary<int, int> LevelKills { get; set; }
        public int TotalKills { get; set; }
    }
}