/*Sam Carpenter
 *Lab 6
 *decellerates as time goes on, bounces back to full speed once hitting a wall
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulcandisc : basicdisc
{
	private float friction;
	
	new public void init(float xx, Transform tr, GameObject ga){
        x = -0.75f;
		z = x - 2 * Mathf.Sign(x);
		t = tr;
		g = ga;
    }
	
	new public void step(){
		if(friction < 0.75f){
			x -= 0.0030f * Mathf.Sign(x);
			z -= 0.0030f * Mathf.Sign(z);
			friction += 0.0030f;
		}
	}
	
	new public void onbounce(){
		x += friction * Mathf.Sign(x);
		z += friction * Mathf.Sign(z);
		friction = 0f;
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
}