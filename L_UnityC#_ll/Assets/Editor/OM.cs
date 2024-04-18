using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class OM : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("OM/EnemySpawner")]
    public static void ShowExample()
    {
        OM wnd = GetWindow<OM>();
        wnd.titleContent = new GUIContent("OM");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //VisualElement label = new Label("Hello World! From C#");
        //root.Add(label);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        AssignBuilderEvents();
    }


    void AssignBuilderEvents()
    {
        var myBtn = rootVisualElement.Q<Button>("BtnSpawn");
        myBtn.clicked += Spawn;
    }

    private void Spawn()
    {
        GameObject.Find("Logic").GetComponent<ObjectSpawner>().SpawnObjectFromPool();

    }
}
