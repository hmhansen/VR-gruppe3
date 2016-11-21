using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public MeshRenderer mesh; //refers to the tower's mesh renderer
    public Color flashColor = new Vector4(255, 0, 0, 0);
    public float flashSpeed = 5f; //the speed the color will fade back to normal
    private GameController gameController;
    public bool boss = false;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    bool damaged;


    // Use this for initialization
    void Start()
    {
        

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        capsuleCollider = GetComponent<CapsuleCollider>();
        mesh = GetComponent<MeshRenderer>();

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (damaged)
        {

            mesh.material.color = flashColor;
        }

        else { mesh.material.color = Color.Lerp(mesh.material.color, Color.grey, flashSpeed * Time.deltaTime); }

        damaged = false;

        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount)
    {
        if (isDead)
        {

            return;
        }
        damaged = true;
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        currentHealth -= amount;

        if (currentHealth <= 0)
        {

            Death();

        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        StartSinking();

        if (boss)
        {
            gameController.ScoreIncrease(50);
        }
        else
        {
            gameController.ScoreIncrease(10);
        }
    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;


        Destroy(gameObject, 2f);
    }
}
