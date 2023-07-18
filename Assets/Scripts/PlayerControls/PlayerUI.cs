using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private TextMeshProUGUI goldText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateGold(float gold)
    {
        goldText.text = gold.ToString("");
    }
    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
