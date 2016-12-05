﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
    public float spawnDelay;
    public float startWait;
    public float waveDelay;

    public bool stop;

	void Start () {
		StartCoroutine( SpawnWaves() );
	}

	IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (!stop) {
            for (int i = 0; i < hazardCount; i++) {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(waveDelay);
        }
	}
}