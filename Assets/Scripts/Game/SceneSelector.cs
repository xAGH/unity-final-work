using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public GameObject[] scenes;
    private int selectedScene;
    public TMP_Text sceneName;

    void SetName() {
        sceneName.text = scenes[selectedScene].name;
    }

    void Start() {
        selectedScene = 0;
        for(int i = 0; i < scenes.Length; i++) {
            if (i == selectedScene) scenes[i].SetActive(true);
            else  scenes[i].SetActive(false);
        }
        SetName();
    }

    public void StartGame() {
        string sceneName = scenes[selectedScene].name;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Next() {
        scenes[selectedScene].SetActive(false);
        selectedScene = (selectedScene + 1) % scenes.Length;
        scenes[selectedScene].SetActive(true);
        SetName();
    }

    public void Previous() {
        scenes[selectedScene].SetActive(false);
        selectedScene--;
        if (selectedScene < 0) {
            selectedScene += scenes.Length;
        }
        scenes[selectedScene].SetActive(true);
        SetName();
    }
}
