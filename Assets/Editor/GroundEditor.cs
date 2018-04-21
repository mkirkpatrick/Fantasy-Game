using UnityEngine;
using UnityEditor;

public class GroundEditor : EditorWindow {

    public GroundPieceDatabase groundDatabase;
    public GroundPiece groundData;
    public int groundIndexMax = 1;

    //GUI Areas
    private Rect topRect;
    private Rect heightRect;
    private Rect positionRect;
    private Rect rotateRect;
    private Rect groundDataRect;

    [MenuItem("My Tools/Ground Editor")]
    public static void ShowWindow() {
        GetWindow<GroundEditor>("Ground Editor");
    }

    void Awake() {
        groundData = new GroundPiece();
        groundData.index = 0;
        groundData.groundType = GroundPiece.GroundType.Straight;
    }

    void OnGUI() {

        DrawTopSection();
        DrawPosition();
        DrawHeight();
        DrawRotate();
        DrawGroundData();

        if (GUI.changed) {
            groundData = groundDatabase.GetGroundPiece(groundData.groundType, groundData.index);
            groundIndexMax = groundDatabase.GetGroundTypeIndexMax(groundData.groundType);
            SetSelectedGroundPiece(groundData);
        }
    }
    
    // Draw UI sections
    private void DrawTopSection() {
        topRect = new Rect(2f, 10f, Screen.width - 4f, 100f);
        GUILayout.BeginArea(topRect);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Ground DB");
        groundDatabase = (GroundPieceDatabase)EditorGUILayout.ObjectField(groundDatabase, typeof(GroundPieceDatabase), true);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUI.Button(new Rect( 10f, 20f, 120f, 2), "Create Piece")) {
                
        }
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
    private void DrawPosition() {

        positionRect = new Rect(2f, 100f, (Screen.width / 2f) - 4f, 120f);
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
        heightRect = new Rect(Screen.width - 120f, 100f, 96f, 100f);
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
        rotateRect = new Rect(Screen.width - 120f, 165f, 96f, 100f);
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
    private void DrawGroundData() {
        groundDataRect = new Rect(2f, 230f, Screen.width - 4f, 100f);
        GUILayout.BeginArea(groundDataRect);

        GUILayout.Label("Ground Data");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        groundData.groundType = (GroundPiece.GroundType)EditorGUILayout.EnumPopup(groundData.groundType);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Index");
        groundData.index = EditorGUILayout.IntSlider(groundData.index, 0, groundIndexMax);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    //Action Functions
    private void SetSelectedGroundPiece(GroundPiece _groundPiece) {
        GroundPiece_gameobj groundPiece = Selection.activeGameObject.GetComponent<GroundPiece_gameobj>();
        groundPiece.groundPieceData = _groundPiece;
        groundPiece.SetGroundPiece(_groundPiece);
    }
}
