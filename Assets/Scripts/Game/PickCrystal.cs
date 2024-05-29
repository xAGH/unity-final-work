using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCrystal : MonoBehaviour
{

    public string crystalName;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.tag.ToLower().Equals("player")) return;
        Destroy(gameObject);
    }

}
