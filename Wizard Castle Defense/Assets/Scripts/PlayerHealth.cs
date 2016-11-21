using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;

    public MeshRenderer mesh; //refers to the tower's mesh renderer
    public Color flashColor = new Vector4(255,0,0,0); //the color it changes to when it takes damage
    public float flashSpeed = 5f; //the speed the color will fade back to normal
    private GameController gameController;
    bool isDead;
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
        gameController.SetCastleIntegrity(currentHealth);
    }
	void Awake () {
        mesh = GetComponent<MeshRenderer>();
        currentHealth = startingHealth;
	}

    void Update()
    {
        if (damaged)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            mesh.material.color = flashColor;
        }

        else { mesh.material.color = Color.Lerp(mesh.material.color, Color.grey, flashSpeed * Time.deltaTime); }

        damaged = false;
    }
	
	public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        gameController.SetCastleIntegrity(currentHealth);

        if (currentHealth <=0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        gameController.GameOver();

        mesh.material.color = Color.blue;
    }

}
