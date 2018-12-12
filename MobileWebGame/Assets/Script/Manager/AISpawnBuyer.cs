using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AISpawnBuyer : MonoBehaviour {

    public Transform[] SpawnLocation;
    public float IdentitityLocation;
    public GameObject BuyerPrefab;

    public float LimitTime;

    public Image TimeperDayImage;
    public float TimeperDayFloat;

    UIMainManager manager;
    ResultManager manager2;

    public int CuacaIndex;

    public Light DirectLight;

    [System.Serializable]
    public class AIpath {
        public Transform[] path;
    }

    public AIpath[] aipaths;

    public Transform[] stackout;

    public Transform TokoGameObject;

    public bool onceDayCount = false;

    public Transform[] PersonNotbBuyLocation;
    public GameObject[] PersonNotbBuy;
    public float LimitTimePerson;

    private void Awake()
    {
        //CuacaIndex = Random.Range(0,100);
        CuacaIndex = 1;
        if (CuacaIndex > 50)
        {
            AllGameManager.instance.CuacaCurr = AllGameManager.instance.Cuaca[0];
            DirectLight.enabled = false;
        }
        else {
            AllGameManager.instance.CuacaCurr = AllGameManager.instance.Cuaca[1];
            DirectLight.enabled = true;
        }


    }


    // Use this for initialization
    void Start () {
        LimitTime = AllGameManager.instance.CuacaCurr.LimitTime;
        manager = FindObjectOfType<UIMainManager>();
        manager2 = FindObjectOfType<ResultManager>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(SpawnBuyer());
      //  StartCoroutine(SpawnPersonNotBuy());
        TimePerDayManager();
	}

    IEnumerator SpawnBuyer() {

        if (LimitTime > 0)
        {
            LimitTime -= Time.fixedDeltaTime;
            yield return 0;
        }
        else {

            manager.TotalPeoplePass += 1;
            int random = Random.Range(0, SpawnLocation.Length);
            Instantiate(BuyerPrefab, SpawnLocation[random].position, SpawnLocation[random].rotation);
            
            LimitTime = AllGameManager.instance.CuacaCurr.LimitTime;

            if (random == 0)
            {
                IdentitityLocation = 1;
            }
            else
            {
                IdentitityLocation = -1;
            }

        }
    }

    IEnumerator SpawnPersonNotBuy()
    {

        if (LimitTimePerson > 0)
        {
            LimitTimePerson -= Time.fixedDeltaTime;
            yield return 0;
        }
        else
        {

          //  manager.TotalPeoplePass += 1;
            int random = Random.Range(0, PersonNotbBuyLocation.Length);
            Instantiate(PersonNotbBuy[0], PersonNotbBuyLocation[random].position, PersonNotbBuy[random].transform.rotation);

           // LimitTime = AllGameManager.instance.CuacaCurr.LimitTime;
          
            if (random <= 2)
            {
                IdentitityLocation = 1;
            }
            else
            {
                IdentitityLocation = -1;
            }
            LimitTimePerson = 2.5f;
        }
    }

    void TimePerDayManager() {
      
        TimeperDayFloat -= Time.deltaTime;
        TimeperDayImage.fillAmount = TimeperDayFloat / 100;
        if (TimeperDayFloat <= 0)
        {
            manager.PanelResultToday.SetActive(true);
            manager.PanelBahanCollection.SetActive(false);
            for (int i = 0; i < AllGameManager.instance.StockMenu.Length; i++)
            {
                AllGameManager.instance.StockMenu[i] = 0;
            }
            Time.timeScale = 0;
            if (!onceDayCount) {
                AllGameManager.instance.DayCount += 1;
                onceDayCount = true;
            }
           
        }
       
    }
}
