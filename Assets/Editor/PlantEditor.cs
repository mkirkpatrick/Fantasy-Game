using UnityEngine;
using UnityEditor;

public class PlantEditor : EditorWindow {

    public PlantDatabase plantDatabase;
    public Chunk_gameobj chunkObj;

    public Plant plantData;
    public int plantIndexMax = 1;
    public int xScale = 1, zScale = 1;

    //GUI Areas
    private Rect topRect;
    private Rect plantDataRect;

    [MenuItem("My Tools/Plant Editor")]
    public static void ShowWindow() {
        GetWindow<PlantEditor>("Plant Editor");
    }

    void Awake() {
        
    }

    void OnGUI() {
        DrawPlantData();

        if (GUI.changed)
        {
            plantData = plantDatabase.GetPlantObject(plantData.plantType, plantData.index);
            plantIndexMax = plantDatabase.GetPlantTypeIndexMax(plantData.plantType);
            SetSelectedPlant(plantData);

            Vector3 newScale = new Vector3(xScale, 1, zScale);
            Selection.activeGameObject.transform.localScale = newScale;
        }
    }

    void OnSelectionChange() {
       
    }

    // Draw UI sections

    private void DrawPlantData()
    {
        plantDataRect = new Rect(2f, 280f, Screen.width - 4f, 100f);
        GUILayout.BeginArea(plantDataRect);

        GUILayout.Label("Plant Data");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        Plant.PlantType newValue = (Plant.PlantType)EditorGUILayout.EnumPopup(plantData.plantType);

        if (newValue != plantData.plantType)
        {
            plantData.plantType = newValue;
            plantData.index = 0;
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Index");
        plantData.index = EditorGUILayout.IntSlider(plantData.index, 0, 11);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    //Action Functions
    private void SetSelectedPlant(Plant _plantData) {
        
    }
}
