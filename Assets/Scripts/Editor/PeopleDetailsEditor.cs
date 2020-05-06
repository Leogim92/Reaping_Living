using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class PeopleDetailsEditor : EditorWindow
{
    string nameToAdd;
    List<string> firstName = new List<string>();
    List<string> lastName = null;
    List<string> story = null;
    int age = 0;
    int eventYear = 0;
    List<KarmaEvent> goodKarmaEvents = null;
    List<KarmaEvent> badKarmaEvents = null;

    [MenuItem("Window/People Details")]
    static void CreateWindow()
    {
        GetWindow<PeopleDetailsEditor>("People Details");
    }

    private void OnGUI()
    {
        GUILayout.Label("Number of first names: " + firstName.Count.ToString(), EditorStyles.boldLabel);
        nameToAdd = EditorGUILayout.TextField("Name to Add", nameToAdd);
        if(GUILayout.Button("Add new field"))
        {
            //firstName.Clear();
            firstName.Add(nameToAdd);
            
        }
        foreach (string name in firstName)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(firstName.IndexOf(name).ToString());
            GUILayout.Label(name);
            GUILayout.EndHorizontal();
        }
    }
    private void OnDisable()
    {
        //appl
    }
}
