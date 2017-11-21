using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

    public GameObject player;
    private GameControl gameControl;

	// Use this for initialization
	void Start () {

        gameControl = player.GetComponent<GameControl>();
        gameControl.grounded = true;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            gameControl.grounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            gameControl.grounded = false;
        }
    }
}
