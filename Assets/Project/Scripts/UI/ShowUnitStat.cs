using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShowUnitStat : MonoBehaviour
{

    [SerializeField]
    protected GameObject unit;

    [SerializeField]
    private float maxValue;

    private Vector2 initialScale;

    GameObject expSlider;
    LevelSystem levelSystem;
    GameObject expText;

    float currentHealth;
    float maxHealth;

    float currentMana;
    float maxMana;

    string healthDisplay;
    // Use this for initialization
    void Start()
    {
        initialScale = gameObject.transform.localScale;
        ExperienceSlider();
    }

    private void ExperienceSlider()
    {
        levelSystem = GameObject.Find("PlayerParty").GetComponent<LevelSystem>();
        expSlider = GameObject.Find("Slider");
        expSlider.GetComponent<Slider>().maxValue = levelSystem.xpnextlevel;
        expSlider.GetComponent<Slider>().value = levelSystem.XP;
        if (levelSystem.XP >= levelSystem.xpnextlevel)
        {
            expSlider.GetComponent<Slider>().value = 0;
        }

        expText = GameObject.Find("PlayerUnitXPText");
        expText.GetComponent<Text>().text = "Level : " + levelSystem.currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (unit != null)
        {
            float newValue = NewStatValue();
            float newScale = (initialScale.x * newValue) / maxValue;
            if (newScale > 1)
            {
                newScale = initialScale.x;
            }
            gameObject.transform.localScale = new Vector2(newScale, initialScale.y);

            DisplayStatNumbers();
        }
    }

    private void DisplayStatNumbers()
    {
        currentHealth = Mathf.RoundToInt(unit.GetComponent<UnitStats>().health);
        maxHealth = Mathf.RoundToInt(unit.GetComponent<UnitStats>().maxHealth);

        GameObject.Find("healthNumbers").GetComponent<Text>().text = currentHealth + " / " + maxHealth;

        currentMana = Mathf.RoundToInt(unit.GetComponent<UnitStats>().mana);
        maxMana = Mathf.RoundToInt(unit.GetComponent<UnitStats>().maxMana);
        GameObject.Find("manaNumbers").GetComponent<Text>().text = currentMana + " / " + maxMana;
    }

    public void ChangeUnit(GameObject newUnit)
    {
        unit = newUnit;
    }

    abstract protected float NewStatValue();
}