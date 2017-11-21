using UnityEngine;
using System.Collections;

public class CannonControl : MonoBehaviour {

    public GameObject spawnposition;
    public GameObject ballprefab;
    public GameObject explosionposition;
    private GameObject persistantObject;
    private PersistantObjScript Script;

    // Use this for initialization
    void Start()
    {
        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
            Script = persistantObject.GetComponent<PersistantObjScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
            transform.Rotate(new Vector3(0, 0, 2.0f));

        if (Input.GetKey(KeyCode.S))
            transform.Rotate(new Vector3(0, 0, -2.0f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cannonball = (GameObject)Instantiate(ballprefab, spawnposition.transform.position, Quaternion.identity);
            cannonball.GetComponent<Rigidbody>().AddExplosionForce(10000.0f, explosionposition.transform.position, 500.0f);
        }

    }
}
