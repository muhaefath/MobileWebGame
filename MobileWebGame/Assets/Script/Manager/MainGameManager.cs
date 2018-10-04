using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainGameManager : MonoBehaviour {

    public GameObject SelectLocation;

    public int IndexLocations;

    public static MainGameManager instance;
    public string[] ListOfScene;

    public int MoneyCurr;
    public Text MoneyText;

    public int PriceStuff;

    public List<Buyer> ListBuyer;
    
    private void Awake()
    {
        MoneyText.text = "" + MoneyCurr;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void TurnOnSelectLocation(int IndexLocation) {
        if (SelectLocation.activeSelf)
        {
            SelectLocation.SetActive(false);
            IndexLocations = IndexLocation;
            SceneManager.LoadScene(ListOfScene[IndexLocation -1]);
        }
        else {
            SelectLocation.SetActive(true);
        }
    }
}
