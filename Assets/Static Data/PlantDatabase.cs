using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Database", menuName = "Static Data/Plant Data")]
[ExecuteInEditMode]
public class PlantDatabase : ScriptableObject {

    public Plant[] grassArray;
    public Plant[] treeArray;
    public Plant[] bushArray;

    public Plant GetPlantObject(Plant.PlantType _plantType, int _index) {

        Plant[] plantArray = null;

        switch (_plantType)
        {
            case Plant.PlantType.Grass:
                plantArray = grassArray;
                break;
        }

        return ClonePlantPiece(plantArray, _index);
    }
    public int GetPlantTypeIndexMax(Plant.PlantType _plantType) {
        int indexMax = 0;

        switch (_plantType)
        {
            case Plant.PlantType.Grass:
                indexMax = grassArray.Length - 1;
                break;
        }
        return indexMax;
    }

    private Plant ClonePlantPiece(Plant[] _array, int _index) {

        Plant newPlant = new Plant(_array[_index].plantType, _index);
        return newPlant;
    }
}