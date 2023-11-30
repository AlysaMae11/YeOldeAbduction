using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUi : MonoBehaviour
{

    public Text moneyText;
    
    void Update()
    {

        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
