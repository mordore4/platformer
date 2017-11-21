using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{

    public GameObject persistantObject;
    public PersistantObjScript Script;

    public void SaveAll ()
    {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
        {
            Script = persistantObject.GetComponent<PersistantObjScript>();

            PlayerPrefs.SetInt("L1Score", Script.scores[1]);
            PlayerPrefs.SetInt("L2Score", Script.scores[2]);
            PlayerPrefs.SetInt("L1Time", Script.timeLevel[1]);
            PlayerPrefs.SetInt("L2Time", Script.timeLevel[2]);
            PlayerPrefs.SetString("Controls", Script.controls);
        }
	}

    public void LoadAll()
    {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
        {
            Script = persistantObject.GetComponent<PersistantObjScript>();

            if (PlayerPrefs.HasKey("L1Score"))
            {
                Script.scores[1] = PlayerPrefs.GetInt("L1Score");
            }
            if (PlayerPrefs.HasKey("L2Score"))
            {
                Script.scores[2] = PlayerPrefs.GetInt("L2Score");
            }
            if (PlayerPrefs.HasKey("L1Time"))
            {
                Script.timeLevel[1] = PlayerPrefs.GetInt("L1Time");
                if (Script.timeLevel[1] != 999)
                {
                    Script.textTimeLevel[1] = "Best time:\n" + Script.timeLevel[1].ToString() + " sec";
                } else Script.textTimeLevel[1] = "";
            }
            if (PlayerPrefs.HasKey("L2Time"))
            {
                Script.timeLevel[2] = PlayerPrefs.GetInt("L2Time");
                if (Script.timeLevel[2] != 999)
                {
                    Script.textTimeLevel[2] = "Best time:\n" + Script.timeLevel[2].ToString() + " sec";
                } else Script.textTimeLevel[2] = "";
                
            }

            if (PlayerPrefs.HasKey("Controls"))
            {
                if (PlayerPrefs.GetString("Controls") == "WASD")
                {
                    Script.forward = KeyCode.W;
                    Script.backward = KeyCode.S;
                    Script.left = KeyCode.A;
                    Script.right = KeyCode.D;

                    Script.controls = "WASD";
                }

                if (PlayerPrefs.GetString("Controls") == "ZQSD")
                {
                    Script.forward = KeyCode.Z;
                    Script.backward = KeyCode.S;
                    Script.left = KeyCode.Q;
                    Script.right = KeyCode.D;

                    Script.controls = "ZQSD";
                }

                if (PlayerPrefs.GetString("Controls") == "ARROW")
                {
                    Script.forward = KeyCode.UpArrow;
                    Script.backward = KeyCode.DownArrow;
                    Script.left = KeyCode.LeftArrow;
                    Script.right = KeyCode.RightArrow;

                    Script.controls = "ARROW";
                }
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ResetGame()
    {
        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        Script = persistantObject.GetComponent<PersistantObjScript>();
        PlayerPrefs.DeleteAll();

        Script.scores[1] = 0;
        Script.scores[2] = 0;
        Script.timeLevel[1] = 999;
        Script.timeLevel[2] = 999;
        Script.textTimeLevel[1] = "";
        Script.textTimeLevel[2] = "";

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}