using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	[SerializeField]
    private GameObject treePrefab;

    private int maxTrees = 3;

    private void Start ()
    {
        int numTrees = Random.Range (0, maxTrees);
        for (int i = 0; i < maxTrees; i++)
        {
            CreateTree ();
        }
    }

    private void CreateTree ()
    {
        GameObject tree = Instantiate (treePrefab) as GameObject;
        tree.transform.parent = transform;
        float randX = Random.Range (-40f, 40f);
        float randZ = Random.Range (-5f, 5f);
        tree.transform.localPosition = new Vector3 (randX, 0, randZ);
    }

}
