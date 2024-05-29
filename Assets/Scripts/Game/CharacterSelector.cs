using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{

    public GameObject[] characters;
    public TMP_Text characterName;
    private int selectedCharacter;

    void SetName() {
        characterName.text = characters[selectedCharacter].name;
    }

    void Start() {
        selectedCharacter = 0;
        for(int i = 0; i < characters.Length; i++) {
            if (i == selectedCharacter) characters[i].SetActive(true);
            else  characters[i].SetActive(false);
        }
        SetName();
    }

    public void StartGame() {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("SceneSelector", LoadSceneMode.Single);
    }

    public void Next() {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        SetName();
    }

    public void Previous() {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0) {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
        SetName();
    }
}
