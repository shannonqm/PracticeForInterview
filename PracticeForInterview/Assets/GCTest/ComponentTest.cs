using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentTest : MonoBehaviour {

    public GameObject obj;
    //public Collider myCollider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(myCollider.name);
        Debug.Log(obj.GetComponent<Collider>().name);
	}
}
