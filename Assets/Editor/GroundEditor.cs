using UnityEngine;
using UnityEditor;

public class GroundEditor : EditorWindow {

    private Rect heightRect;
    private Rect positionRect;
    private Rect rotateRect;

    [MenuItem("My Tools/Ground Editor")]
    public static void ShowWindow() {
        GetWindow<GroundEditor>("Ground Editor");
    }

    void OnGUI() {

        DrawPosition();
        DrawHeight();
        DrawRotate();
    }

    private void DrawPosition() {

        positionRect = new Rect(2f, 20f, (Screen.width / 2f) - 4f, 120f);
        GUILayout.BeginArea(positionRect);

        GUILayout.Label("Location");

        if ( GUI.Button(new Rect((Screen.width / 4f) - 15f, 20f, 30f, 30f),"N") )
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 1f);
                obj.transform.position = newPos;
            }
        }
        if (GUI.Button(new Rect((Screen.width / 4f) - 45f, 50f, 30f, 30f), "W"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x - 1f, obj.transform.position.y, obj.transform.position.z);
                obj.transform.position = newPos;
            }
        }
        if (GUI.Button(new Rect((Screen.width / 4f) + 15f, 50f, 30f, 30f), "E"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x + 1f, obj.transform.position.y, obj.transform.position.z);
                obj.transform.position = newPos;
            }
        }
        if (GUI.Button(new Rect((Screen.width / 4f) - 15f, 80f, 30f, 30f), "S"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newPos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z -1f);
                obj.transform.position = newPos;
            }
        }
        GUILayout.EndArea(); 
    }
    private void DrawHeight() {
        heightRect = new Rect(Screen.width - 120f, 20f, 96f, 100f);
        GUILayout.BeginArea(heightRect);

        GUILayout.Label("Height");

        if (GUILayout.Button("▲ Raise ▲"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newHeight = new Vector3(obj.transform.position.x, obj.transform.position.y + .125f, obj.transform.position.z);
                obj.transform.position = newHeight;
            }
        }
        if (GUILayout.Button("▼ Lower ▼"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Vector3 newHeight = new Vector3(obj.transform.position.x, obj.transform.position.y - .125f, obj.transform.position.z);
                obj.transform.position = newHeight;
            }
        }
        GUILayout.EndArea();
    }
    private void DrawRotate() {
        rotateRect = new Rect(Screen.width - 120f, 100f, 96f, 100f);
        GUILayout.BeginArea(rotateRect);

        GUILayout.Label("Rotate");

        if (GUILayout.Button("▲ +90 ▼"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y + 90f, obj.transform.eulerAngles.z);
            }
        }
        if (GUILayout.Button("▼ -90 ▲"))
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.eulerAngles = new Vector3(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y - 90f, obj.transform.eulerAngles.z);
            }
        }

        GUILayout.EndArea();
    }
}
