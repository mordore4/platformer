using UnityEngine;
using System.Collections;

public class TurnStar : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 80 * Time.deltaTime, 0, Space.World);
    }
}
