using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPoints : MonoBehaviour {

    public Image PrefabImage;
    RectTransform rectParent;
    private float parentWidth;

    private float starWidth;

    private string levelName;
    private int levelNameLength;
    private int levelNumber;

    private GameObject[] allLevels;
    private int amountLevels;

    private GameObject persistantObject;
    private PersistantObjScript Script;

    void Start()
    {

        persistantObject = GameObject.Find("PersistantObject") as GameObject;
        Script = persistantObject.GetComponent<PersistantObjScript>();

        rectParent = (RectTransform)this.gameObject.transform;
        parentWidth = rectParent.rect.width;

        starWidth = parentWidth / 6;

        levelName = this.gameObject.name;
        levelNameLength = levelName.Length;
        levelNumber = int.Parse(levelName[levelNameLength - 3].ToString() + levelName[levelNameLength - 2].ToString() + levelName[levelNameLength - 1].ToString());

        allLevels = GameObject.FindGameObjectsWithTag("LevelStarter");
        amountLevels = allLevels.Length;

        for (int numberOfStar = 1; numberOfStar <= 5; numberOfStar++)
        {
            PrefabImage = Instantiate(PrefabImage) as Image;
            PrefabImage.transform.SetParent(transform);
            PrefabImage.rectTransform.pivot = new Vector2(0, 0);
            PrefabImage.rectTransform.sizeDelta = new Vector2(starWidth, starWidth);

            if (numberOfStar == 1)
            {
                PrefabImage.rectTransform.anchoredPosition = new Vector2(starWidth / 2, -20f);
            }
            else PrefabImage.rectTransform.anchoredPosition = new Vector2(starWidth * numberOfStar - starWidth / 2, -20f);

            CheckColor(numberOfStar);

        }

    }

    private void CheckColor(int numberOfStar)
    {
        for (int numberOfLevel = 1; numberOfLevel <= amountLevels; numberOfLevel++)
        {
            if (levelNumber == numberOfLevel)
            {
                if (Script.scores[numberOfLevel] >= numberOfStar)
                {
                    PrefabImage.GetComponent<Image>().color = new Color(255, 255, 0);
                } else PrefabImage.GetComponent<Image>().color = new Color(107, 107, 107);
            }
        }
    }
}
