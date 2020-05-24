using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour, IMouseInteractable
{
    GameObject tutorial = null;
    [SerializeField] Texture2D cursorIcon =null;
    
    PersonData[] peopleInScene;

    public static event Action OnUnsealedFates;
    public static event Action OnKarmaGoalFailed;
    public static event Action OnNextLevelTrigger;
    
    private void Awake()
    {
        tutorial = GameObject.FindGameObjectWithTag("Tutorial");
        peopleInScene = FindObjectsOfType<PersonData>();
    }
    public void StartInteraction( PlayerStats playerStats)
    {
        foreach (PersonData person in peopleInScene)
        {
            if (person.IsFateSealed == false)
            {
                OnUnsealedFates?.Invoke();
                return;
            }
        }
        if (playerStats.Karma < playerStats.KarmaGoal && !tutorial)
        {
            OnKarmaGoalFailed?.Invoke();
            return;
        }
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        OnNextLevelTrigger?.Invoke();
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
