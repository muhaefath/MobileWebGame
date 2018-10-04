using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBuyer : MonoBehaviour {

    public bool BuyNot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ControlAI();  
	}

    void ControlAI()
    {
        if (!BuyNot)
        {
            transform.Translate(-10f * Time.fixedDeltaTime, 0, 0);
        }
        else if (BuyNot)
        {
            StartCoroutine(BuyStuff());
        }
    }

    IEnumerator BuyStuff() {
        yield return new WaitForSeconds(2f);
        BuyNot = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LimitDoor")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Toko")
        {
            int random = Random.Range(0,2);
            if (random == 0) {
                return;
            }
            BuyNot = true;
            MainGameManager.instance.MoneyCurr += MainGameManager.instance.PriceStuff;
            MainGameManager.instance.MoneyText.text = "" + MainGameManager.instance.MoneyCurr;
        }
    }
}
