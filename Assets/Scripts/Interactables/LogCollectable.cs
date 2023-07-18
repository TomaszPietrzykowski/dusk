using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCollectable : Interactable
{
    [SerializeField]
    private int value = 6;
    public int GetValue()
    {
        return value;
    }


    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
