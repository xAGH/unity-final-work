using UnityEngine;

public class SpawnCrystals : MonoBehaviour
{

    private float maxY, minY, maxX, minX;
    public  GameObject parent;
    public GameObject[] crystals;

    void Awake()
    {
        maxY = GameObject.Find("Boundaries/Top").transform.position.y - 1; 
        minY = GameObject.Find("Boundaries/Bottom").transform.position.y + 1;
        maxX = GameObject.Find("Boundaries/Right").transform.position.x - 1;
        minX = GameObject.Find("Boundaries/Left").transform.position.x + 1;

        GenerateCrystals();
    }

    void GenerateCrystals() {
        foreach (GameObject crystal in crystals) {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            GameObject crystalInstance = Instantiate(crystal, new Vector3(x, y, 0), Quaternion.identity);
            crystalInstance.transform.parent = parent.transform;
        }
    }

}
