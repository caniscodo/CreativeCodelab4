using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverStats : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    private void Start()
    {
        // Set the text for both TextMeshPro elements
        text1.text = $"{GlobalData.instance.globalFishCounter}";
        text2.text = $"{GlobalData.instance.globalGoldFishCounter}";
    }
 
}
