using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersistantObjScript : MonoBehaviour {

    private static bool created = false;

    public int[] timeLevel = new int[10];

    public string[] textTimeLevel = new string[10];

    public int[] scores = new int[10];

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    public string controls;


    void Awake()
    {
        if (!created)
        {
            created = true;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
