using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPerson : MonoBehaviour {

    AISpawnBuyer manager6;
    public float DirectionIdentity;


    private void Awake()
    {
        manager6 = FindObjectOfType<AISpawnBuyer>();
    }
    // Use this for initialization
    void Start () {
        DirectionIdentity = manager6.IdentitityLocation;
        if (DirectionIdentity == 1)
        {
            transform.rotation = Quaternion.Euler(this.transform.rotation.x, -90, this.transform.rotation.z);
           
        }
        else {
            transform.rotation = Quaternion.Euler(this.transform.rotation.x, 90, this.transform.rotation.z);
            DirectionIdentity = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, 25f  * DirectionIdentity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "LimitDoor")
        {
            Destroy(gameObject);
        }
    }
}
