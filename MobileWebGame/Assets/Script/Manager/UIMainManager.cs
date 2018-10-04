using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIMainManager : MonoBehaviour {

    public GameObject PanelPause;

    public int MoneyCurr;
    public Text MoneyCurrText;
	// Use this for initialization
	void Start () {
        PanelPause.SetActive(false);
        MoneyCurr = MainGameManager.instance.PriceStuff;
    }
	
	// Update is called once per frame
	void Update () {
        MoneyCurrText.text = "" + MoneyCurr;
	}

    public void PauseMenu() {
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeMenu()
    {
        MoneyCurr = MainGameManager.instance.PriceStuff ;
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void SaveResumeMenu()
    {
        MainGameManager.instance.PriceStuff = MoneyCurr;
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitMenu() {
        SceneManager.LoadScene("Main");
    }

    public void AddPrice() {
        MoneyCurr += 10;
    }

    public void MinusPrice()
    {
        MoneyCurr -= 10;
    }
}
