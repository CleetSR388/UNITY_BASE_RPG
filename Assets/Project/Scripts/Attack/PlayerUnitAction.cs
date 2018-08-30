using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour
{

    [SerializeField]
    private GameObject physicalAttackPrefab;

    [SerializeField]
    private GameObject magicalAttackPrefab;

    [SerializeField]
    public GameObject FireballPrefab;

    [SerializeField]
    private GameObject usePotionPrefab;

    [SerializeField]
    private Sprite faceSprite;

    public GameObject currentAttack;
    private GameObject physicalAttack;
    private GameObject magicalAttack;
    public GameObject usePotion;
    public GameObject useManaPotion;
    public bool _manaPotion;
    public bool _potion;
    UnitStats unitStats;

    void Awake()
    {
        physicalAttack = Instantiate(physicalAttackPrefab, transform);
        magicalAttack = Instantiate(magicalAttackPrefab, transform);
        usePotion = Instantiate(usePotionPrefab, transform);

        physicalAttack.GetComponent<AttackTarget>().owner = gameObject;
        magicalAttack.GetComponent<AttackTarget>().owner = gameObject;

        currentAttack = physicalAttack;
    }

    public void Act(GameObject target)
    {
        if (currentAttack == usePotion)
        {
            unitStats = this.gameObject.GetComponent<UnitStats>();
            unitStats.usePotion();
            target = null;
            //currentAttack.GetComponent<UsePotion>().Heal(target);
        }
        else if (currentAttack == useManaPotion)
        {
            unitStats = this.gameObject.GetComponent<UnitStats>();
            unitStats.useManaPotion();
            target = null;
        }
        else
        {
            currentAttack.GetComponent<AttackTarget>().Hit(target);
        }
    }

    public void SelectAttack(bool physical, bool potion, bool manaPotion)
    {
        if (!potion && !manaPotion)
        {
            currentAttack = physical ? physicalAttack : magicalAttack;
            _potion = false;
        }
        else if (potion == true)
        {
            currentAttack = usePotion;
            _potion = true;
        }
        else
        {
            currentAttack = useManaPotion;
            _manaPotion = true;
        }
    }

    public void UpdateHUD()
    {
        GameObject playerUnitFace = GameObject.Find("PlayerUnitFace");
        playerUnitFace.GetComponent<Image>().sprite = faceSprite;

        GameObject playerUnitHealthBar = GameObject.Find("PlayerUnitHealthBar");
        playerUnitHealthBar.GetComponent<ShowUnitHealth>().ChangeUnit(gameObject);

        GameObject playerUnitManaBar = GameObject.Find("PlayerUnitManaBar");
        playerUnitManaBar.GetComponent<ShowUnitMana>().ChangeUnit(gameObject);
    }

    [SerializeField]
    protected Transform fireballpos;

    public virtual void ThrowFireball(int value)
    {

        {
            GameObject tmp = (GameObject)Instantiate(FireballPrefab, fireballpos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
         
        }
    }
}