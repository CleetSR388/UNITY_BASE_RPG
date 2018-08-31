using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject attackPrefab;

	[SerializeField]
	private string targetsTag;

    [SerializeField]
    public GameObject BoomPrefab;

    private GameObject attack;

	void Awake () {
		attack = Instantiate (attackPrefab);
		attack.GetComponent<AttackTarget> ().owner = gameObject;
	}

	private GameObject FindRandomTarget () {
		GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag (targetsTag);

		if (possibleTargets.Length > 0) {
			return possibleTargets[Random.Range(0, possibleTargets.Length)];
		} else {
			return null;
		}
	}

	public void Act () {
		GameObject target = FindRandomTarget ();
		attack.GetComponent<AttackTarget> ().Hit (target);
	}

    [SerializeField]
    protected Transform Boompos;

    public virtual void ThrowBoom(int value)
    {

        {
            GameObject tmp = (GameObject)Instantiate(BoomPrefab, Boompos.position, Quaternion.Euler(new Vector3(0, 0, -180)));

        }
    }
}
