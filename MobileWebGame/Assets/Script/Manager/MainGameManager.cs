using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainGameManager : MonoBehaviour {

    public GameObject SelectLocation;

    public int IndexLocations;

    public string[] ListOfScene;

   

   

    public void TurnOnSelectLocation(int IndexLocation) {
        if (SelectLocation.activeSelf)
        {
            SelectLocation.SetActive(false);
            IndexLocations = IndexLocation;
            SceneManager.LoadScene(ListOfScene[IndexLocation -1]);
        }
        else {
            SelectLocation.SetActive(true);
        }
    }
}
