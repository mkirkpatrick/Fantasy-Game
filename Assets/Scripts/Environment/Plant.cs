using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Plant {

    public enum PlantType { Grass, Tree, Bush}

    public PlantType plantType;
    public int index;

    public Plant(PlantType _plantType, int _index) {
        plantType = _plantType;
        index = _index;
    }
}
