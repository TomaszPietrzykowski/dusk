using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    [SerializeField]
    private float gold = 0f;

    private PlayerUI playerUI;
    void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
    }

    public void AddGold(float amount)
    {
        gold += amount;
        playerUI.UpdateGold(gold);
    }

    public float GetGold()
    {
        return gold;
    }
}
