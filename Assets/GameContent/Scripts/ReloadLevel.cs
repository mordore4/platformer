using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour {

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
