using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainGameManager : MonoBehaviour {

    public GameObject SelectLocation;

    public int IndexLocations;

    public MainGameManager instance;
    public string[] ListOfScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }

    }

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
