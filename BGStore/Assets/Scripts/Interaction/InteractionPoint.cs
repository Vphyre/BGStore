using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionPoint : MonoBehaviour
{
    public UnityEvent OnObjectInteract;

    public void ObjectInteractEvent()
    {
        OnObjectInteract.Invoke();
    }
}
