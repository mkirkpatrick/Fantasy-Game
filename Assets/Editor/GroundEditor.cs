using UnityEngine;
using UnityEditor;

public class GroundEditor : EditorWindow {

    public bool editMode = false;

    [MenuItem("My Tools/Ground Editor")]
    public static void ShowWindow() {
        GetWindow<GroundEditor>("Ground Editor");
    }

    void OnGUI() {

        if (GUILayout.Button("▲▲▲ Raise Height ▲▲▲")) {
            foreach (GameObject obj in Selection.gameObjects) {
                Vector3 newHeight = new Vector3(obj.transform.position.x, obj.transform.position.y + .125f, obj.transform.position.z);
                obj.transform.position = newHeight;
            }
        }
        if (GUILayout.Button(" ▼▼▼ Lower Height ▼▼▼"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newHeight = new Vector3(obj.transform.position.x, obj.transform.position.y - .125f, obj.transform.position.z);
                obj.transform.position = newHeight;
            }
        }
    }
}
