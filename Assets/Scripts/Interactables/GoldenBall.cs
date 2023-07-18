using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenBall : Interactable
{
    [SerializeField]
    private float value = 2f;
    public float GetValue()
    {
        return value;
    }


    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
