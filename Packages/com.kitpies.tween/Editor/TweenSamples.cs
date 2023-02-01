#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TweenSamples : EditorWindow
{
    [MenuItem("Window/UI Toolkit/Tween Samples")]
    public static void ShowExample()
    {
        TweenSamples wnd = GetWindow<TweenSamples>();
        wnd.titleContent = new GUIContent("Tween Samples");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Packages/com.kitpies.tween/Samples/Main.uxml");
        VisualElement contentFromUXML = visualTree.Instantiate();
        root.Add(contentFromUXML);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Packages/com.kitpies.tween/Samples/Main.uss");
        root.styleSheets.Add(styleSheet);
    }
}
#endif