using System;
using System.Collections.Generic;

[Serializable]
public class SaveDataBox {
    public Dictionary<int, int> LevelKills { get; set; }
    public int TotalKills { get; set; }
}