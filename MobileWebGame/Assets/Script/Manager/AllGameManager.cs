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

    public int[] StockMenu;

    public int DayCount;

    [System.Serializable]
    public class CuacaManage {
        public int IndexCuaca;
        public float ProbabilityCuaca;
        public float LimitTime;
    }

    public CuacaManage[] Cuaca;
    public CuacaManage CuacaCurr;

    [System.Serializable]
    public class TokoManage {
        public string NamaAtribut;
        public int LevelAtribut;
        public int PriceNextLevel;
        public int chaceEfecct;
    }

    public TokoManage[] tokomanage;
    public bool[] RukoActive;


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
    void Start() {
        MoneyText.text = "" + MoneyCurr;
    }

    // Update is called once per frame
    void Update() {

    }

    public void SavePlayers() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayers() {
       PlayerData data =   SaveSystem.loadPlayer();

        MoneyCurr = data.Money;
        DayCount = data.DayCount;
        for (int i = 0; i < RukoActive.Length; i++)
        {
            RukoActive[i] = data.RukoSelect[i];
        }
    }
}
