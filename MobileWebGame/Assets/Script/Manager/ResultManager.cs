using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour {

    public Text TotalIncomeText;
    public Text TotalDay;
    public Text TotalPeopleBuy;
    public Text TotalPeopleCancelBuy;
    public Text TotalPeopleCome;
  

    public UIMainManager manager;
    // Use this for initialization
    private void Awake()
    {
      //  manager = FindObjectOfType<UIMainManager>();
    }
    void Start () {
 
        TotalIncomeText.text = "" + manager.TotalIncome;
        TotalPeopleBuy.text = "" + manager.TotalPeopleBuy;
        TotalDay.text = "" + AllGameManager.instance.TodayInt;
        TotalPeopleCome.text = "" + manager.TotalPeoplePass;
        TotalPeopleCancelBuy.text = "" + manager.TotalPeopleCancelBuy;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CloseResultMenu(string nama) {
        AllGameManager.instance.TodayInt += 1;
        SceneManager.LoadScene(nama);
    }
}
