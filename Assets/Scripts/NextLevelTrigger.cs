using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour, IMouseInteractable
{
    [SerializeField] Texture2D cursorIcon =null;

    PersonData[] peopleInScene;

    public static event Action OnNextLevelTrigger;
    private void Awake()
    {
        peopleInScene = FindObjectsOfType<PersonData>();
    }
    public void StartInteraction( PlayerStats playerStats)
    {
        foreach (PersonData person in peopleInScene)
        {
            if (person.IsFateSealed == false)
            {
                Debug.Log("You haven't sealed all the fates yet");
                return;
            }
        }
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        OnNextLevelTrigger();
        Invoke("LoadScene",1.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeMouseCursor (Texture2D mouseCursor)
    {
        Cursor.SetCursor(mouseCursor, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseOver()
    {
        ChangeMouseCursor(cursorIcon);
    }
    private void OnMouseExit()
    {
        ChangeMouseCursor(default);
    }
}
