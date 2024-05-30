using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryCrystal : MonoBehaviour
{
    public static InventoryCrystal Instance;

    public GameObject[] crystals;
    private int recolectedCrystals;

    public void AddCrystal(int index)
    {
        crystals[index].SetActive(true);
        recolectedCrystals ++;
        if (recolectedCrystals == 3) {
            Win();
        }
    }

    void Win() {
        SceneManager.LoadScene("SceneSelector", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    void Start()
    {
        recolectedCrystals = 0;
        foreach(GameObject crystal in crystals) {
            crystal.SetActive(false);
        }
         if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}