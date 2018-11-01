using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIPauseManager : MonoBehaviour {

    public GameObject[] PanelCollection; // Buyatri ; price
    public GameObject ParentBuy;

    UIMainManager manager;

    // Use this for initialization
    void Start() {
        manager = FindObjectOfType<UIMainManager>();
        for (int i = 0; i < ParentBuy.transform.childCount; i++)
        {
            ParentBuy.transform.GetChild(i).GetComponentInChildren<Text>().text = "" + AllGameManager.instance.tokomanage[i].PriceNextLevel;
        }
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < ParentBuy.transform.childCount; i++)
        {
            if (AllGameManager.instance.MoneyCurr < AllGameManager.instance.tokomanage[i].PriceNextLevel)
            {
                ParentBuy.transform.GetChild(i).GetComponentInChildren<Button>().interactable = false ;
            }
            
        }
    }

    public void PanelManage(int index){
        for (int i = 0; i < PanelCollection.Length; i++)
        {
            PanelCollection[i].SetActive(false);
        }
        PanelCollection[index].SetActive(true);
    }

    public void BuyAtribut(int index) {
        AllGameManager.instance.tokomanage[index].LevelAtribut += 1;
        AllGameManager.instance.MoneyCurr -=  AllGameManager.instance.tokomanage[index].PriceNextLevel;
        AllGameManager.instance.MoneyText.text = "" + AllGameManager.instance.MoneyCurr;

        manager.MoneyCurr = AllGameManager.instance.MoneyCurr;
  

    
      
    }

}
