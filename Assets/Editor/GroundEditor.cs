using UnityEngine;
using UnityEditor;

public class GroundEditor : EditorWindow {

    public GroundPieceDatabase groundDatabase;
    public Chunk_gameobj chunkObj;

    public GroundPiece groundData;
    public int groundIndexMax = 1;
    public int xScale = 1, zScale = 1;

    //GUI Areas
    private Rect topRect;
    private Rect heightRect;
    private Rect positionRect;
    private Rect rotateRect;
    private Rect scaleRect;
    private Rect groundDataRect;

    [MenuItem("My Tools/Ground Editor")]
    public static void ShowWindow() {
        GetWindow<GroundEditor>("Ground Editor");
    }

    void Awake() {
        groundData = new GroundPiece(0, GroundPiece.GroundType.Flat);
        groundData.index = 0;
    }

    void OnGUI() {

        DrawTopSection();
        DrawPosition();
        DrawHeight();
        DrawRotate();
        DrawScale();
        DrawGroundData();

        if (GUI.changed)
        {
            if (Selection.activeGameObject.name == "GroundPiece") {
                Vector3 pos = Selection.activeGameObject.transform.position;
                Vector3 groundRot = Selection.activeGameObject.transform.localEulerAngles;
                DestroyImmediate(Selection.activeGameObject);
                Selection.activeGameObject = groundDatabase.GetGroundPiece(groundData.groundType, groundData.index);
                Selection.activeGameObject.transform.parent = chunkObj.transform;
                Selection.activeGameObject.transform.position = pos;
                Selection.activeGameObject.transform.eulerAngles = groundRot;

            }

            groundIndexMax = groundDatabase.GetGroundTypeIndexMax(groundData.groundType);

            Vector3 newScale = new Vector3(xScale, 1, zScale);
            Selection.activeGameObject.transform.localScale = newScale;
        }
    }

    void OnSelectionChange() {
        if (Selection.activeGameObject.transform.parent.gameObject.name == "GroundPiece") {
            Selection.activeGameObject = Selection.activeGameObject.transform.parent.gameObject;
        }
            

        if (Selection.activeGameObject != null) {
            
            groundData = Selection.activeGameObject.GetComponent<GroundPiece_gameobj>().groundPieceData;
            xScale = (int)Selection.activeGameObject.transform.localScale.x;
            zScale = (int)Selection.activeGameObject.transform.localScale.z;
            Repaint();

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
        GUILayout.Label("Chunk Target");
        chunkObj = (Chunk_gameobj)EditorGUILayout.ObjectField(chunkObj, typeof(Chunk_gameobj), true);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUI.Button(new Rect( 10f, 40f, 120f, 20f), "Create Piece")) {
            Vector3 groundPos = chunkObj.transform.position;
            Vector3 groundRot = Selection.activeGameObject.transform.localEulerAngles;
            
            if (Selection.activeGameObject != null)
                groundPos = Selection.activeGameObject.transform.position;

            GameObject newGroundPiece = groundDatabase.GetGroundPiece(groundData.groundType, groundData.index);
            newGroundPiece.transform.parent = chunkObj.transform;
            newGroundPiece.transform.position = groundPos;

            newGroundPiece.transform.eulerAngles = groundRot;

            //New pieces match scale
            newGroundPiece.transform.localScale = Selection.activeGameObject.transform.localScale;
            
            Selection.activeGameObject = newGroundPiece;
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
    private void DrawScale() {
        scaleRect = new Rect(2f, 220f, Screen.width - 4f, 100f);
        GUILayout.BeginArea(scaleRect);

        GUILayout.Label("Scale");
        GUILayout.BeginHorizontal();
        GUILayout.Label("X");
        xScale = EditorGUILayout.IntSlider(xScale, 1, 20);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Z");
        zScale = EditorGUILayout.IntSlider(zScale, 1, 20);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
    private void DrawGroundData() {
        groundDataRect = new Rect(2f, 280f, Screen.width - 4f, 100f);
        GUILayout.BeginArea(groundDataRect);

        GUILayout.Label("Ground Data");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Type");
        GroundPiece.GroundType newValue = (GroundPiece.GroundType)EditorGUILayout.EnumPopup(groundData.groundType);

        if (newValue != groundData.groundType) {
            groundData.groundType = newValue;
            groundData.index = 0;
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Index");
        groundData.index = EditorGUILayout.IntSlider(groundData.index, 0, groundIndexMax);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }

    //Action Functions
    private void SetSelectedGroundPiece(GroundPiece _groundPiece) {
       
    }
}
