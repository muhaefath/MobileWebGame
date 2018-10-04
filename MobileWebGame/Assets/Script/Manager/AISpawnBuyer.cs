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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(SpawnBuyer());
        TimeperDayFloat -= Time.deltaTime;
        TimeperDayImage.fillAmount = TimeperDayFloat / 250;
	}

    IEnumerator SpawnBuyer() {

        if (LimitTime > 0)
        {
            LimitTime -= Time.fixedDeltaTime;
            yield return 0;
        }
        else {

            int random = Random.Range(0, SpawnLocation.Length);
            Instantiate(BuyerPrefab, SpawnLocation[random].position, SpawnLocation[random].rotation);
            LimitTime = 3f;
        }
    }
}
