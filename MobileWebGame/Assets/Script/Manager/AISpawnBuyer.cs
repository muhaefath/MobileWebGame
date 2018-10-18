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



    // Use this for initialization
    void Start () {
        manager = FindObjectOfType<UIMainManager>();
        manager2 = FindObjectOfType<ResultManager>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(SpawnBuyer());
      //  TimePerDayManager();
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
            LimitTime = 3f;
        }
    }

    void TimePerDayManager() {
        TimeperDayFloat -= Time.deltaTime;
        TimeperDayImage.fillAmount = TimeperDayFloat / 35;
        if (TimeperDayFloat <= 0)
        {
            manager.PanelResultToday.SetActive(true);
            manager.PanelBahanCollection.SetActive(false);
        }
    }
}
