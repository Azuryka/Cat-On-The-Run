using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string name;
    public int score;
}

[Serializable]
public class PlayerDataList
{
    public List<PlayerData> data;
}