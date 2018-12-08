using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData  {


    public int Money;
    public int Level;
    public bool[] RukoSelect = new bool[6];
    public int DayCount;

    public PlayerData(AllGameManager player) {
        Money = player.MoneyCurr;
        player.MoneyText.text = "" + player.MoneyCurr;
        DayCount = player.DayCount;

        for (int i = 0; i < RukoSelect.Length; i++)
        {
            RukoSelect[i] = player.RukoActive[i];
        }

    }
}
