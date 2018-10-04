using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerIdentity : MonoBehaviour {

    public Buyer identityBuyer;

    private void Awake()
    {
        identityBuyer = MainGameManager.instance.ListBuyer[Random.Range(0, MainGameManager.instance.ListBuyer.Count)];
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
