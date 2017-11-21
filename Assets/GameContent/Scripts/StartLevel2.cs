using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel2 : MonoBehaviour {

    private GameObject Level;

    public void startLevel()
    {
        Level = this.gameObject;
        string levelname = Level.name;
        SceneManager.LoadScene(levelname);
    }
}
