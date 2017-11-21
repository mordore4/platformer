using UnityEngine;
using System.Collections;

public class ChangeControls : MonoBehaviour
{

    private GameObject persistantObject;
    private PersistantObjScript Script;

    public GameObject ctrPanel;


    public void showPanel()
    {
        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        Script = persistantObject.GetComponent<PersistantObjScript>();
        ctrPanel.SetActive(true);
    }

    public void hidePanel()
    {
        ctrPanel.SetActive(false);
    }

    public void WASD()
    {
        Script.forward = KeyCode.W;
        Script.backward = KeyCode.S;
        Script.left = KeyCode.A;
        Script.right = KeyCode.D;

        Script.controls = "WASD";
    }

    public void ZQSD()
    {
        Script.forward = KeyCode.Z;
        Script.backward = KeyCode.S;
        Script.left = KeyCode.Q;
        Script.right = KeyCode.D;

        Script.controls = "ZQSD";
    }

    public void ARROW()
    {
        Script.forward = KeyCode.UpArrow;
        Script.backward = KeyCode.DownArrow;
        Script.left = KeyCode.LeftArrow;
        Script.right = KeyCode.RightArrow;

        Script.controls = "ARROW";
    }
}
