using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Interactive_ball")
        {
            Debug.Log("HALLO");
            Destroy(this.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
        
	}
}
