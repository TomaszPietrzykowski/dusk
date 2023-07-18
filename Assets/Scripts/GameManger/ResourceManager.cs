using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    
    [SerializeField]
    private int wood = 0;

    private PlayerUI playerUI;
    void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
    }

    public void AddWood(int amount)
    {
        wood += amount;
        playerUI.UpdateWood(wood);
    }

    public int GetWood()
    {
        return wood;
    }
}
