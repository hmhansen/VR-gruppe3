using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
    private EnemySpawner spawnController;
    private bool restart = false;
    // Use this for initialization
    void Start () {
        GameObject spawnControllerObject = GameObject.FindWithTag("SpawnPoint");
        if (spawnControllerObject != null)
        {
            spawnController = spawnControllerObject.GetComponent<EnemySpawner>();
        }
        if (spawnController == null)
        {
            Debug.Log("Cannot find 'EnemySpawner' script");
        }

        Debug.Log("dsadas");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (restart)
        {
            SceneManager.LoadScene("Tower24");

        }
        else
        {
            restart = true;
            Debug.Log("Truffet");
            spawnController.StartSpawn();
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.FindChild("StartText").gameObject.GetComponent<MeshRenderer>().enabled = false;
            transform.FindChild("StartText").localPosition = new Vector3(-0.5f, 0.1f, 0);
        }
    }
    
    }
