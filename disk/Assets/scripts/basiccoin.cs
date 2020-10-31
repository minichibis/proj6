using System.Collections;
/*Sam Carpenter
 *Lab 6
 *objective
 */

using System.Collections.Generic;
using UnityEngine;

public class basiccoin : harmfulobject
{
	private Transform t;
	private GameObject g;
	private GameObject p;
	
    public void init(float xx, Transform tr, GameObject ga){

    }
	
	public void init(GameObject pa, Transform tr, GameObject ga){
		p = pa;
		t = tr;
		g = ga;
	}
	
	public void step(){
		
	}
	
	public void onbounce(){
		
	}
	
	public void ontouchplayer(){
		GameObject.Instantiate(p, new Vector3(t.position.x * -1, 0.5f, t.position.z * -1), new Quaternion());
		float x = Random.Range(7f, 20f);
		x *= Mathf.Sign(Random.Range(-1, 1));
		float z = Random.Range(7f, 20f);
		z *= Mathf.Sign(Random.Range(-1, 1));
		t.position = new Vector3(x, 0.5f, z);
		GameObject.FindGameObjectsWithTag("Singleton")[0].GetComponent<singleton>().coins++;
	}
	
	public float getx(){
		return 0f;
	}
	
	public float getz(){
		return 0f;
	}
}
