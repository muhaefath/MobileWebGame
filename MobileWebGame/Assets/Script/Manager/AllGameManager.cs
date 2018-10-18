using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllGameManager : MonoBehaviour {

    public static AllGameManager instance;

    public int MoneyCurr;
    public Text MoneyText;

    public int PriceStuff;

    public List<Buyer> ListBuyer;
    public List<Menu> ListMenu;

    public List<int> GoalPerDay;
    public int TodayInt;

    public float ProbabilityBuy;

    [System.Serializable]
    public class CuacaManage {
        public int IndexCuaca;
        public float ProbabilityCuaca;
        
    }

    public CuacaManage[] Cuaca;

    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        MoneyText.text = "" + MoneyCurr;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
