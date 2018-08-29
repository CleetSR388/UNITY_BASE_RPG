using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttackPrefab;

	[SerializeField]
	private GameObject magicalAttackPrefab;

    [SerializeField]
    private GameObject usePotionPrefab;

    [SerializeField]
	private Sprite faceSprite;

	public GameObject currentAttack;
	private GameObject physicalAttack;
	private GameObject magicalAttack;
    public GameObject usePotion;
    public bool _potion;
    UnitStats unitStats;

	void Awake () {
		physicalAttack = Instantiate (physicalAttackPrefab, transform);
		magicalAttack = Instantiate (magicalAttackPrefab, transform);
        usePotion = Instantiate(usePotionPrefab, transform);

		physicalAttack.GetComponent<AttackTarget> ().owner = gameObject;
		magicalAttack.GetComponent<AttackTarget> ().owner = gameObject;

		currentAttack = physicalAttack;
	}

	public void Act (GameObject target) {
        if (currentAttack == usePotion)
        {
           unitStats = this.gameObject.GetComponent<UnitStats>();
           unitStats.usePotion();
            target = null;
            //currentAttack.GetComponent<UsePotion>().Heal(target);
        }
        else
        {
            currentAttack.GetComponent<AttackTarget>().Hit(target);
        }
	}

	public void SelectAttack (bool physical, bool potion) {
        if (!potion)
        {
            currentAttack = physical ? physicalAttack : magicalAttack;
            _potion = false;
        }
        else
        {
            currentAttack = usePotion;
            _potion = true;
        }
	}

	public void UpdateHUD() {
		GameObject playerUnitFace = GameObject.Find ("PlayerUnitFace");
		playerUnitFace.GetComponent<Image> ().sprite = faceSprite;

		GameObject playerUnitHealthBar = GameObject.Find ("PlayerUnitHealthBar");
		playerUnitHealthBar.GetComponent<ShowUnitHealth> ().ChangeUnit (gameObject);

		GameObject playerUnitManaBar = GameObject.Find ("PlayerUnitManaBar");
		playerUnitManaBar.GetComponent<ShowUnitMana> ().ChangeUnit (gameObject);
	}
}
