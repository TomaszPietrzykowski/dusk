using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollectible : Interactable
{
    [SerializeField]
    private int value = 1;
    public int GetValue()
    {
        return value;
    }


    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
