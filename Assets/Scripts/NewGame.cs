using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {
	
	void Start () {
		valueStore.valStore.setLevel(1);
		valueStore.valStore.setLives(2);
		valueStore.valStore.setScore(0);
		valueStore.valStore.setScrap(0);
		Destroy(this.gameObject);
	}

}
