using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
    public float spawnDelay;
    public float startWait;
    public float waveDelay;

    public GUIText scoreText;
    private int score;

    public GUIText restartText;
    public GUIText gameOverText;
    private bool gameOver;
    private bool restart;

    void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        score = 0;
        UpdateScore();
		StartCoroutine( SpawnWaves() );
	}

    private void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (!gameOver) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);

            if (gameOver) {
                restartText.text = "Press 'R' to restart.";
                restart = true;
                break;
            }
        }
	}

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        UpdateScore();

    }

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!!!!!";
        gameOver = true;
    }
}
