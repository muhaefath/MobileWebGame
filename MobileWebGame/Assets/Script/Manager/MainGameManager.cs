using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainGameManager : MonoBehaviour {

    public GameObject SelectLocation;
    public GameObject StockManage;

    public int IndexLocations;

    public string[] ListOfScene;


    public int[] StockPerItem;
    public Text[] StockPerItemText;
    public int[] PricePerStock;

    public int[] StockPerItemCurr;
    public int MoneyGameCurr;

    public Button[] PlusCollection;
    public Button[] MinusCollection;
    public Button[] CancelSubmit;

    public GameObject PanelAreyousure;

    private void Start()
    {
        SelectLocation.SetActive(true);
        StockManage.SetActive(false);
        PanelAreyousure.SetActive(false);

        for (int i = 0; i < StockPerItem.Length; i++)
        {
            StockPerItemText[i].text = "" + StockPerItem[i];
            StockPerItemCurr[i] = StockPerItem[i];
            MinusCollection[i].interactable = false;
        }

       
        MoneyGameCurr = AllGameManager.instance.MoneyCurr;

    }




    public void TurnOnSelectLocation(int IndexLocation) {
        if (SelectLocation.activeSelf)
        {
            SelectLocation.SetActive(false);
            StockManage.SetActive(true);
            IndexLocations = IndexLocation;
            Time.timeScale = 1;
           
            // SceneManager.LoadScene(ListOfScene[IndexLocation -1]);
        }
        else {
            SelectLocation.SetActive(true);
        }
    }


    public void MinusStock(int index)
    {


        StockPerItem[index] -= 1;
        StockPerItemText[index].text = "" + StockPerItem[index];

        AllGameManager.instance.MoneyCurr += PricePerStock[index];
        AllGameManager.instance.MoneyText.text = "" + AllGameManager.instance.MoneyCurr;

        if (StockPerItem[index] == 0)
        {
            MinusCollection[index].interactable = false;
        }
        for (int i = 0; i < PricePerStock.Length; i++)
        {
            if (AllGameManager.instance.MoneyCurr > PricePerStock[i])
            {
                PlusCollection[i].interactable = true;
            }
        }
    }

    public void PlusStock(int index)
    {

        StockPerItem[index] += 1;
        StockPerItemText[index].text = "" + StockPerItem[index];

        AllGameManager.instance.MoneyCurr -= PricePerStock[index];
        AllGameManager.instance.MoneyText.text = "" + AllGameManager.instance.MoneyCurr;

        if (StockPerItem[index] > 0)
        {
            MinusCollection[index].interactable = true;
        }
        for (int i = 0; i < PricePerStock.Length; i++)
        {
            if (AllGameManager.instance.MoneyCurr < PricePerStock[i])
            {
                PlusCollection[i].interactable = false;
            }
        }
    }

    public void CancelSave()
    {
        for (int i = 0; i < StockPerItem.Length; i++)
        {
            StockPerItem[i] = StockPerItemCurr[i];
            StockPerItemText[i].text = "" + StockPerItem[i];
            MinusCollection[i].enabled = false;
            PlusCollection[i].enabled = true;
        }

        AllGameManager.instance.MoneyCurr = MoneyGameCurr;
        AllGameManager.instance.MoneyText.text = "" + AllGameManager.instance.MoneyCurr;
    }

    public void SaveSubmit()
    {
        for (int i = 0; i < 3; i++)
        {
            AllGameManager.instance.StockMenu[i] = StockPerItem[i];

        }
        PanelAreyousure.SetActive(true);
        // SceneManager.LoadScene(ListOfScene[IndexLocations - 1]);
    }

    public void AreYouSureYes() {
        SceneManager.LoadScene(ListOfScene[IndexLocations - 1]);
    }

    public void AreYouSureNo() {
        for (int i = 0; i < 3; i++)
        {
            AllGameManager.instance.StockMenu[i] = StockPerItemCurr[i] ;

        }
        CancelSave();
        PanelAreyousure.SetActive(false);
    }
}
