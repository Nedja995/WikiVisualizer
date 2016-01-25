//C# Example

using UnityEngine;
using UnityEditor;
using System.Collections;

class DataParserEditor : EditorWindow
{
    [MenuItem("EventVis/Data Parser")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(DataParserEditor));
    }

    void OnGUI()
    {
        // The actual window code goes here
    }
}