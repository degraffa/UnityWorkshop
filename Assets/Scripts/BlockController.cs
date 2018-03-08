using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockController : MonoBehaviour {
    public float blockSpeed = 17f;
    public float waitTime = 1f;


    [SerializeField]
    Text scoreText;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject floor;

    int score;

    GameObject prefab;
    List<GameObject> blocks = new List<GameObject>();


    private void Start() {
        score = 0;
        scoreText.text = "Score: " + score;
        InvokeRepeating("SpawnBlocks", 0.0f, waitTime);
    }

    void Update () {
        if(player.transform.position.y < -10) {
            this.enabled = false;
        }
        for(int i = 0; i < blocks.Count; i++) {
            if(blocks[i].transform.position.z > -20) {
                blocks[i].transform.Translate(Vector3.back * blockSpeed * Time.deltaTime);
            } else {
                score++;
                scoreText.text = "Score: " + score;
                GameObject.Destroy(blocks[i]);
                blocks.Remove(blocks[i]);
            }
        }
	}


    void SpawnBlocks() {
        int blockNumber = Random.Range(0, 3);
        switch (blockNumber) { 
            case(0):
                prefab = (GameObject)Instantiate(Resources.Load("LeftOrRight"));
                prefab.transform.position = new Vector3(
                    this.transform.position.x - 2.5f * floor.transform.localScale.x, 
                    prefab.transform.localScale.y / 2f, 
                    this.transform.position.z
                );
                break;
             case(1):
                prefab = (GameObject)Instantiate(Resources.Load("LeftOrRight"));
                prefab.transform.position = new Vector3(
                    this.transform.position.x + 2.5f * floor.transform.localScale.x, 
                    prefab.transform.localScale.y / 2f, 
                    this.transform.position.z
                );
                break;
             case(2): 
                prefab = (GameObject)Instantiate(Resources.Load("Jump"));
                prefab.transform.position = new Vector3(
                    this.transform.position.x, 
                    prefab.transform.localScale.y / 2f,
                    this.transform.position.z
                );
                break;
            default:
                Debug.Log("This should never happen");
                break;
        }

        blocks.Add(prefab);
    }
}
