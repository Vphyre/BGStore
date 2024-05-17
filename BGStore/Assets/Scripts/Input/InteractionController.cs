using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private PlayerInputs playerInputs;
    private InteractionPoint objectToInteract;
    private void Awake()
    {
       playerInputs = new PlayerInputs();
    }
    private void Start()
    {
        playerInputs.Main.Interact.performed += ctx => Interact();    
    }
    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
    private void Interact()
    {
        if(objectToInteract != null)
        {
            objectToInteract.ObjectInteractEvent();
            SetObjectToNull();
        }
    }
    public void SetObjectToIteract(InteractionPoint value)
    {
        objectToInteract = value;
    }
    public void SetObjectToNull()
    {
        objectToInteract = null;
    }
}
