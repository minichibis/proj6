/*Sam Carpenter
 *Lab 6
 *this is disc room
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicdisc : harmfulobject
{
	protected float x = 1f;
	protected float z = 1f;
	protected Transform t;
	protected GameObject g;
	protected float bound = 25f;
	
    public void init(float xx, Transform tr, GameObject ga){
        x = xx;
		z = x - 2 * Mathf.Sign(x);
		t = tr;
		g = ga;
    }
	
	public void init(GameObject p, Transform tr, GameObject g){
		
	}
	
	public void step(){
		
	}
	
	public void onbounce(){
		if(t.position.x > bound){
			t.Translate(Vector3.right * (bound - t.position.x));
			x *= -1;
		}
		if(t.position.x < bound * -1){
			t.Translate(Vector3.right * ((bound * -1) - t.position.x));
			x *= -1;
		}
		if(t.position.z > bound){
			t.Translate(new Vector3(0, 0, 1) * (bound - t.position.z));
			z *= -1;
		}
		if(t.position.z < bound * -1){
			t.Translate(new Vector3(0, 0, 1) * ((bound * -1) - t.position.z));
			z *= -1;
		}
	}
	
	public void ontouchplayer(){
		GameObject.FindGameObjectsWithTag("Singleton")[0].GetComponent<singleton>().gaming = false;
	}
	
	public float getx(){
		return x;
	}
	
	public float getz(){
		return z;
	}
}
