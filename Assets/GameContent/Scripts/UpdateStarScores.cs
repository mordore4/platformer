using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateStarScores : MonoBehaviour {

    public GameObject persistantObject;
    public PersistantObjScript Script;

    private int level1Score;
    private int level2Score;

    public Image l1Star1;
    public Image l1Star2;
    public Image l1Star3;
    public Image l1Star4;
    public Image l1Star5;
    public Image l2Star1;
    public Image l2Star2;
    public Image l2Star3;
    public Image l2Star4;
    public Image l2Star5;

    private Image imageL1Star1;
    private Image imageL1Star2;
    private Image imageL1Star3;
    private Image imageL1Star4;
    private Image imageL1Star5;
    private Image imageL2Star1;
    private Image imageL2Star2;
    private Image imageL2Star3;
    private Image imageL2Star4;
    private Image imageL2Star5;

    // Use this for initialization
    void Start () {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        if (persistantObject != null)
        {
            Script = persistantObject.GetComponent<PersistantObjScript>();

            level1Score = Script.scores[1];
            level2Score = Script.scores[2];
	
            imageL1Star1 = l1Star1.GetComponent<Image>();
            imageL1Star2 = l1Star2.GetComponent<Image>();
            imageL1Star3 = l1Star3.GetComponent<Image>();
            imageL1Star4 = l1Star4.GetComponent<Image>();
            imageL1Star5 = l1Star5.GetComponent<Image>();
            imageL2Star1 = l2Star1.GetComponent<Image>();
            imageL2Star2 = l2Star2.GetComponent<Image>();
            imageL2Star3 = l2Star3.GetComponent<Image>();
            imageL2Star4 = l2Star4.GetComponent<Image>();
            imageL2Star5 = l2Star5.GetComponent<Image>();


            if (level1Score >= 1)
            {
                imageL1Star1.color = new Color(255, 255, 0);
            }
            if (level1Score >= 2)
            {
                imageL1Star2.color = new Color(255, 255, 0);
            }
            if (level1Score >= 3)
            {
                imageL1Star3.color = new Color(255, 255, 0);
            }
            if (level1Score >= 4)
            {
                imageL1Star4.color = new Color(255, 255, 0);
            }
            if (level1Score == 5)
            {
                imageL1Star5.color = new Color(255, 255, 0);
            }


            if (level2Score >= 1)
            {
                imageL2Star1.color = new Color(255, 255, 0);
            }
            if (level2Score >= 2)
            {
                imageL2Star2.color = new Color(255, 255, 0);
            }
            if (level2Score >= 3)
            {
                imageL2Star3.color = new Color(255, 255, 0);
            }
            if (level2Score >= 4)
            {
                imageL2Star4.color = new Color(255, 255, 0);
            }
            if (level2Score == 5)
            {
                imageL2Star5.color = new Color(255, 255, 0);
            }
        }
        

    }
}
