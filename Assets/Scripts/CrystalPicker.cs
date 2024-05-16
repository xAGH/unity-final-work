using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPicker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.tag.ToLower().Equals("crystal")) return;
        Destroy(collision.gameObject);
    }
}
