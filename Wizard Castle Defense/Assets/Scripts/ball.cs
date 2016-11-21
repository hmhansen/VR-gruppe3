using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("HALLO");
            Destroy(col.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
