using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInteractable
{
    void StartInteraction(PlayerStats playerStats);
    void ChangeMouseCursor(Texture2D mouseCursor);
}
