using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    // template method pattern:
    // https://dotnettutorials.net/lesson/template-method-design-pattern/
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact(){}
    
    public void Remove()
    {
        gameObject.SetActive(false);
    }
}
