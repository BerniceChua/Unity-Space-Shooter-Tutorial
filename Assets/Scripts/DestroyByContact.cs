using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject asteroidExplosion;
	public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    private void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerObject == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) {
		if (other.tag == "Invisible Boundary") {
			return;
		}

		Instantiate(asteroidExplosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			//GameController.GameOver ();
		}

        gameController.AddScore(scoreValue);

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
