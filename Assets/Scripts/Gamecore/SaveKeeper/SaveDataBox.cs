using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveDataBox {
    public Dictionary<int, int> LevelKills { get; set; }
    public int TotalKills { get; set; }
}