using UnityEngine;
using System.Collections;

public class DestroyAtBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
