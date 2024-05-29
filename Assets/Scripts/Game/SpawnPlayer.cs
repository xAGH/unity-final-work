using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaenPlayer : MonoBehaviour
{
    
    public GameObject[] characters;

    void Start()
    {
        int playerIndex = PlayerPrefs.GetInt("SelectedCharacter");
        GameObject player = characters[playerIndex];
        player.transform.position = transform.position;
        player.SetActive(true);
        player.name = "Player";
        player.tag = "Player";
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.SetLocalPositionAndRotation(new Vector3(0, 0, -10), Quaternion.Euler(0, 0, 0));
    }

}
