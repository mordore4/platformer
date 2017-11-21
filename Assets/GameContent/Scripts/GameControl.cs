using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {

    private static GameControl control;

    private Rigidbody rb;
    public int speed;
    private Vector3 camvector;

    private float groundedHeight = 0.55f;
    public bool grounded = true;
    public float jumpHeight;

    public bool paused = false;

    private GameObject cam;

    public GameObject pauseScreen;
    public GameObject quitConfirm;

    private GameObject persistantObject;
    private PersistantObjScript Script;

    private KeyCode forwardKey;
    private KeyCode backwardKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

    // Use this for initialization
    void Start () {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
            Script = persistantObject.GetComponent<PersistantObjScript>();

        rb = GetComponent<Rigidbody>();
        getCamvector();
        cam = GameObject.Find("Main Camera");
        Time.timeScale = 1f;

        forwardKey = Script.forward;
        backwardKey = Script.backward;
        leftKey = Script.left;
        rightKey = Script.right;

	}
	
    void Update(){

        getCamvector();

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }


        if ((grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))))
        {
            GetComponent<Rigidbody>().velocity = (new Vector3(0, jumpHeight, 0));
        }

    }

	void FixedUpdate () {

        Vector3 mainForce = new Vector3 (camvector.x, 0, camvector.z);

        if (Input.GetKey(forwardKey))
        {
            rb.AddForce(mainForce * speed);
        }

        if (Input.GetKey(backwardKey))
        {
            rb.AddForce(mainForce * -speed);
        }
            
        if (Input.GetKey(leftKey))
        {
            rb.AddForce(Quaternion.Euler(0, -90, 0) * mainForce * speed);
        }

        if (Input.GetKey(rightKey))
        {
            rb.AddForce(Quaternion.Euler(0, 90, 0) * mainForce * speed);
        }
    }

    void getCamvector()
    {
        camvector = Camera.main.transform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moving Platform"))
        {
            groundedHeight = 0.8f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Moving Platform"))
        {
            groundedHeight = 0.55f;
        }
    }

    public void togglePause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            cam.GetComponent<MouseOrbitImproved>().enabled = true;
            pauseScreen.SetActive(false);
            paused = false;
            
        }
        else
        {
            Time.timeScale = 0f;
            cam.GetComponent<MouseOrbitImproved>().enabled = false;
            pauseScreen.SetActive(true);
            paused = true;
        }
    }

    public void confirmQuit()
    {
        quitConfirm.SetActive(true);
    }

    public void dontQuit()
    {
        quitConfirm.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
