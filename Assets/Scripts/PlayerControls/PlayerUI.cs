using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private TextMeshProUGUI woodText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateWood(int wood)
    {
        woodText.text = wood.ToString("");
    }
    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
