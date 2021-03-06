﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameplayNormal : MonoBehaviour {

    public Text countTekst;
    public Text deathCount;
    public Text victoryText;
    public Image star1;
    public Image star2;
    public Image star3;

    public int time5Star;
    public int time4Star;

    private string levelName;
    private int levelNameLength;
    private int levelNumber;

    private Image imageStar1;
    private Image imageStar2;
    private Image imageStar3;

    public GameObject trap1;

    public GameObject timer;
    public GameObject victoryScreen;

    private bool lost;
    private int amountDeaths;
    private int starsPickedUp;
    private int amountStars;

    private int time;

    public int score;
    private bool pointLostTime1;
    private bool pointLostTime2;

    private bool awarded1;
    private bool awarded2;
    private bool awarded3;

    public GameObject persistantObject;
    public PersistantObjScript persistantScript;


    // Use this for initialization
    void Start()
    {
        lost = false;
        amountDeaths = 0;
        starsPickedUp = 0;

        imageStar1 = star1.GetComponent<Image>();
        imageStar2 = star2.GetComponent<Image>();
        imageStar3 = star3.GetComponent<Image>();

        GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");
        amountStars = collectables.Length;

        updateTime();

        updateCountText();
        updateDeathCount();
        score = 2;
        pointLostTime1 = false;
        pointLostTime2 = false;

        awarded1 = false;
        awarded2 = false;
        awarded3 = false;

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
            persistantScript = persistantObject.GetComponent<PersistantObjScript>();

        levelName = SceneManager.GetActiveScene().name;
        levelNameLength = levelName.Length;
        levelNumber = int.Parse(levelName[levelNameLength - 3].ToString() + levelName[levelNameLength - 2].ToString() + levelName[levelNameLength - 1].ToString());
    }

    void LateUpdate()
    {

        var player = GameObject.Find("Player");
        float playerHeight = player.transform.position.y;

        if (playerHeight < -2.0f)
        {
            lost = true;
            Debug.Log("you lose");
        }
        else lost = false;

        if (lost)
        //inCaseOfLose();
        {
            player.transform.position = new Vector3(0, 1.0f, -2.0f);
            amountDeaths += 1;
        }
        updateDeathCount();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            updateTime();
            if (!pointLostTime1 && time >= time5Star)
            {
                score -= 1;
                pointLostTime1 = true;
            }
            if (!pointLostTime2 && time >= time4Star)
            {
                score -= 1;
                pointLostTime2 = true;
            }
            Debug.Log("Finished with " + score.ToString() + "/5");

            if (score > persistantScript.scores[levelNumber])
            {
                persistantScript.scores[levelNumber] = score;
            }

            if (time < persistantScript.timeLevel[levelNumber])
            {
                persistantScript.timeLevel[levelNumber] = time;
                persistantScript.textTimeLevel[levelNumber] = "Best time:\n" + time.ToString() + " sec";
            }


            victoryText.text = "You collected " + starsPickedUp.ToString() + " out of " + amountStars.ToString() + " stars.\nYou beat the level in " + time.ToString() + "seconds\n\nThis earned you a total of " + score.ToString() + "/5 points";
            victoryScreen.SetActive(true);
            Time.timeScale = 0f;

            //Some firework things
            //Initialize victory screen
        }

        if (other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            starsPickedUp += 1;
            updateCountText();
            if (!awarded1 && starsPickedUp >= (amountStars / 3) - 0.001f)
            {
                imageStar1.color = new Color(255, 255, 0);
                score += 1;
                awarded1 = true;
            }
            if (!awarded2 && starsPickedUp >= ((amountStars * 2) / 3) - 0.001f)
            {
                imageStar2.color = new Color(255, 255, 0);
                score += 1;
                awarded2 = true;
            }
            if (!awarded3 && starsPickedUp >= ((amountStars * 3) / 3) - 0.001f)
            {
                imageStar3.color = new Color(255, 255, 0);
                score += 1;
                awarded2 = true;
            }
        }
        if (other.CompareTag("Trap Trigger"))
        {
            trap1.GetComponent<Rigidbody>().isKinematic = false;
            trap1.GetComponent<Rigidbody>().useGravity = true;
            trap1.GetComponent<MeshCollider>().enabled = false;
        }
    }

    void updateCountText()
    {
        countTekst.text = "You collected:\n" + starsPickedUp.ToString() + " out of " + amountStars.ToString() + " stars.";
    }

    void updateDeathCount()
    {
        string plural = "";
        if (amountDeaths > 1 || amountDeaths == 0)
        {
            plural = "s";
        }
        deathCount.text = "You died " + amountDeaths.ToString() + " time" + plural + ".";
    }

    void updateTime()
    {
        time = timer.GetComponent<Timer>().playtime;
    }
}
