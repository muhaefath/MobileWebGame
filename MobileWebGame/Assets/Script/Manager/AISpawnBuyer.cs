using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AISpawnBuyer : MonoBehaviour {

    public Transform[] SpawnLocation;
    public GameObject BuyerPrefab;

    public float LimitTime;

    public Image TimeperDayImage;
    public float TimeperDayFloat;

    UIMainManager manager;
    ResultManager manager2;

    public int CuacaIndex;

    public Light DirectLight;

    private void Awake()
    {
        CuacaIndex = Random.Range(0,100);
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
        }
       
    }
}
