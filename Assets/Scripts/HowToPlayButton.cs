using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayButton : MonoBehaviour
{
    public GameObject rulesScreen;
    public bool activeRulesScreen = false;

    public void RulesScreen()
    {
        if (activeRulesScreen)
        {
            rulesScreen.SetActive(false);
            activeRulesScreen = false;
        } else
        {
            rulesScreen.SetActive(true);
            activeRulesScreen = true;
        }
    }


}
