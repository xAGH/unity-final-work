using UnityEngine;

public class SpawnCrystals : MonoBehaviour
{

    private float maxY, minY, maxX, minX;

    public Transform topBoundary;
    public Transform bottomBoundary;
    public Transform leftBoundary;
    public Transform rightBoundary;
    public GameObject[] crystals;

    void Awake()
    {
        maxY = topBoundary.position.y - 1; 
        minY = bottomBoundary.position.y + 1;
        maxX = rightBoundary.position.x - 1;
        minX = leftBoundary.position.x + 1;

        GenerateCrystals();
    }

    void GenerateCrystals() {
        GameObject parent = new();
        int crystalsLength = crystals.Length;
        int i = 0;
        while (i < crystalsLength) {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Vector3 position = new(x, y, 0);
            Collider[] intersecting = Physics.OverlapSphere(position, 1f);
            if (intersecting.Length == 0) {
                GameObject crystal = Instantiate(crystals[i], position, Quaternion.identity, parent.transform);
                crystal.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Layer 3");
                i++;
            }
        }
    }

}
