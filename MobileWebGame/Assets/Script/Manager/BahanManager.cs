using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BahanManager : MonoBehaviour {
    UIMainManager manager;
    public List<Button> BahanCollection;

    public bool StackOn;
    // Use this for initialization
    void Start () {
        manager = FindObjectOfType<UIMainManager>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            BahanCollection.Add(this.transform.GetChild(i).GetComponent<Button>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (StackOn)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                BahanCollection[i].interactable = true;
            }
        }
        else if (manager.StackBuyer.Count == 0)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                BahanCollection[i].interactable = false ;
            }
        }
        */
	}

    public void PressButtonBahan(int indexBahan) {
        if (manager.StackBuyer[0].menu == indexBahan)
        {
          

           manager.StackBuyer[0].Served = true;
            
        } 
        Debug.Log(indexBahan);
    }
}
