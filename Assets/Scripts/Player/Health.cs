using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static int health;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake() {
        health = 3;
    }

    void Update() {
        foreach (Image img in hearts) {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++) {
            hearts[i].sprite = fullHeart;
        }
    }
}
