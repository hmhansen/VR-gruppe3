using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour
{
    public float radius = 5;
    public float timer;
    public int damage = 1;

    public float scaleSpeed;
    Vector3 newScale;
    Vector3 scaleIncrease;
    public Vector3 maxScale;
    bool released = false;

    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;
    

    void Start() {
       
        newScale = transform.localScale;
        scaleIncrease = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];
        noise2 = sounds[1];
    }
    void Update()
    {
        if (!released) {
            if (newScale.x <= maxScale.x)
            {
                transform.localScale = newScale;
            }
            newScale += scaleIncrease * Time.deltaTime;
        }
    }
    void OnTriggerEnter(Collider col)
    {

        /*if (col.tag == "StartButton") {
            if (spawnPoint == null)
            {
                Debug.Log("Finner ikke spawnpoint");
            }
            //spawnPoint.SetActive(true);
        }/*
        /*

            if (other.gameObject.tag == "Enemy")
            {

                /*GameController controller = GameObject.Find("GameController").GetComponent<GameController>(); //look around for an object named gamecontroller with a GameController script attached

                controller.ScoreIncrease(collision.collider.GetComponent<EnemyHealth>().scoreValue); //tell the gamecontroller to increase the score equal to the amount we've found in the "enemy" creature

                Destroy(collision.collider); //destroy the enemy gameObject
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            */
        noise2.Play();
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        child.SetActive(true);

        StartCoroutine(Countdown());
        
    }
    public void Release() {
        released = true;
    }
    IEnumerator Countdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}