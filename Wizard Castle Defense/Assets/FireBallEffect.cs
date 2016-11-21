using UnityEngine;
using System.Collections;

public class FireBallEffect : MonoBehaviour {
    public int damage;
    public float scaleSpeed;
    Vector3 newScale;
    Vector3 scaleIncrease;
    public Vector3 maxScale;
    private ArrayList AlreadyHit;
    void Start() {
        newScale = gameObject.transform.localScale;
        scaleIncrease = new Vector3(scaleSpeed, scaleSpeed, scaleSpeed);
    }
    void Update() {
        transform.localScale = newScale;
        newScale += scaleIncrease * Time.deltaTime;
        if(newScale.x > maxScale.x) {
            newScale = transform.localScale;
        }
    }
    void OnTriggerEnter(Collider col) {
        EnemyHealth enemy = col.GetComponent<EnemyHealth>();
        //if enemy is NOT in alreadyhitarray

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log("Oooooooh, buuuuurn");
        }
    }
}
