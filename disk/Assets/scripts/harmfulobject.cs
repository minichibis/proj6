/*Sam Carpenter
 *Lab 6
 *template for collidey objects (which usually hurt)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface harmfulobject
{
	void init(float xx, Transform tr, GameObject g);
	void init(GameObject p, Transform tr, GameObject g);
	void step();
    void onbounce();
	void ontouchplayer();
	float getx();
	float getz();
}
