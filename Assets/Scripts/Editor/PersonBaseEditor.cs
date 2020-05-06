using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PersonBase))]
public class PersonBaseEditor : Editor
{
    PersonBase personBase;
    private void OnEnable()
    {
        personBase = (PersonBase)base.target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(15);
        if (personBase.karmaEvent)
        {
            GUILayout.Label("Karma Event Description", EditorStyles.boldLabel);
            DisplayKarmaAlignment();
            DisplayKarmaEventDescription();
        }
    }

    private void DisplayKarmaAlignment()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Karma Alignment");
        EditorGUILayout.TextField(UpperFirst(personBase.karmaEvent.karmaAlignment.ToString()));
        EditorGUILayout.EndHorizontal();
    }
    private void DisplayKarmaEventDescription()
    {
        EditorGUILayout.TextField("Karma Event Description",personBase.karmaEvent.eventDescription, GUILayout.Height(100), GUILayout.Width(450));
        EditorStyles.textField.wordWrap = true;
    }
    private static string UpperFirst(string text)
    {
        return char.ToUpper(text[0]) +
            ((text.Length > 1) ? text.Substring(1).ToLower() : string.Empty);
    }
}
