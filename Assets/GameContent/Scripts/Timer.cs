using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public int playtime;
    private int seconds;
    private int minutes;

    public Text timePast;


	void Start () {

        playtime = 0;
        seconds = 0;
        minutes = 0;
        StartCoroutine("playTimer");
	}

    private IEnumerator playTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = playtime % 60;
            minutes = (playtime / 60) % 60;

            timePast.text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }
    }
}
