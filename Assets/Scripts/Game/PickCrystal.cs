using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCrystal : MonoBehaviour
{

    public string crystalName;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.tag.ToLower().Equals("player")) return;
        InventoryCrystal inventario = InventoryCrystal.Instance;
        if (crystalName.Equals("Blue Crystal"))
        {
            inventario.AddCrystal(0);
        } else if (crystalName.Equals("Orange Crystal"))
        {
            inventario.AddCrystal(1);
        }else if (crystalName.Equals("Red Crystal"))
        {
            inventario.AddCrystal(2);
        }
        Destroy(gameObject);
    }

}
