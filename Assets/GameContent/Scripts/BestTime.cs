using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BestTime: MonoBehaviour {

    public GameObject persistantObject;
    public PersistantObjScript Script;

    public Text timeL1Best;
    public Text timeL2Best;
 
	void Start () {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
        {
            Script = persistantObject.GetComponent<PersistantObjScript>();

            timeL1Best.text = Script.textTimeLevel[1];
            timeL2Best.text = Script.textTimeLevel[2];
        }

            
	}
}
