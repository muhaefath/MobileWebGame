using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMainManager : MonoBehaviour {

    public GameObject PanelPause;

    public int MoneyCurr;
    public Text MoneyCurrText;

    public GameObject PanelResultToday;
    public GameObject PanelBahanCollection;

    public float TotalPeoplePass;
    public float TotalPeopleBuy;
    public float TotalPeopleCometoBooth;
    public float TotalPeopleCancelBuy;
    public float TotalIncome;
    

    public Image GoalPerDayImage;

    public float ProbabilityBuyCurr;

    public List<AIBuyer> StackBuyer;
    public Transform[] StackPosition;
    public Transform StackPositionOut;

    // Use this for initialization
    void Start () {
        PanelPause.SetActive(false);
        PanelResultToday.SetActive(false);
        MoneyCurr = AllGameManager.instance.PriceStuff;
        ProbabilityBuyCurr = AllGameManager.instance.ProbabilityBuy;


    }
	
	// Update is called once per frame
	void Update () {
        MoneyCurrText.text = "" + MoneyCurr;
        GoalPerDayImage.fillAmount = TotalIncome / AllGameManager.instance.GoalPerDay[AllGameManager.instance.TodayInt - 1];
	}

    public void PauseMenu() {
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeMenu()
    {
        MoneyCurr = AllGameManager.instance.PriceStuff ;
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void SaveResumeMenu()
    {
        AllGameManager.instance.PriceStuff = MoneyCurr;
        AllGameManager.instance.ProbabilityBuy = ProbabilityBuyCurr; 
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitMenu() {
        SceneManager.LoadScene("Main");
    }

    public void AddPrice() {
        MoneyCurr += 10;
        ProbabilityBuyCurr -= 5;
    }

    public void MinusPrice()
    {
        MoneyCurr -= 10;
        ProbabilityBuyCurr += 5;
    }
}
