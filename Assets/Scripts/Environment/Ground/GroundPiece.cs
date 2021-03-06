﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundPiece {
    public enum GroundType { Flat, Straight, Corner, Ramp, Path };

    public int index;
    public GroundType groundType;
    public int[] materialIDs;

    public Vector3 location;
    public int rotation;
    public float xScale, yScale;

    public GroundPiece(int _index, GroundType _groundType) {
        index = _index;
        groundType = _groundType;
    }
}
