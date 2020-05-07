using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInteractable
{
    void StartInteraction(PointManager points);
    void ChangeMouseCursor(Texture2D mouseCursor);
}
