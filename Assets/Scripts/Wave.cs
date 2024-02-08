﻿using UnityEngine;
using System.Collections.Generic;
using System;
using OneLine;

[Serializable]
public class SpawnItemData
{
    public float delay;
    public bool isBomb;
    [Range(-5, 5)] public float x;
    public Vector2 velocity = new Vector2(0, 10f);

    public bool isRandomPosition;
    public bool isRandomVelocity;
    public bool isRandomBomb;
}

[Serializable]
public class Wave
{
    [OneLineWithHeader]public List<SpawnItemData> items;
}
