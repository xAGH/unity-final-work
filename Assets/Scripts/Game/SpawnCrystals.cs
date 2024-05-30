using UnityEngine;

public class SpawnCrystals : MonoBehaviour
{
    public GameObject[] crystals;
    public PolygonCollider2D polygonCollider;

    void Start() {
        GenerateCrystals();
    }

    void GenerateCrystals() {
        GameObject parent = new();
        int i = 0;
        while (i < crystals.Length) {
            Vector2 position = RandomPointInBounds(polygonCollider.bounds, 1f);
            Vector2 rndPointInside = polygonCollider.ClosestPoint(new Vector2(position.x, position.y));
            Collider[] intersecting = Physics.OverlapSphere(position, 1f);
            if (rndPointInside.x == position.x && rndPointInside.y == position.y && intersecting.Length == 0)
            {
                GameObject crystal = Instantiate(crystals[i], position, Quaternion.identity, parent.transform);
                crystal.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Layer 3");
                i++;
                crystal.SetActive(true);
            }
        }
    }

private Vector3 RandomPointInBounds(Bounds bounds, float scale)
    {
        return new Vector3(
            Random.Range(bounds.min.x * scale, bounds.max.x * scale),
            Random.Range(bounds.min.y * scale, bounds.max.y * scale),
            Random.Range(bounds.min.z * scale, bounds.max.z * scale)
        );
    }
}
