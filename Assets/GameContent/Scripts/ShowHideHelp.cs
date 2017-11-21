using UnityEngine;
using System.Collections;

public class ShowHideHelp : MonoBehaviour {

    public GameObject helpScreen;

    public void openHelp()
    {
        helpScreen.SetActive(true);
    }

    public void closeHelp()
    {
        helpScreen.SetActive(false);
    }
}
