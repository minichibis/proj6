/*Sam Carpenter
 *Lab 6
 *basic movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{
	public float speed = 2f;
	private float bound = 25f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical"); 
		
		if (GameObject.FindGameObjectsWithTag("Singleton")[0].GetComponent<singleton>().gaming == false){
			x = 0;
			z = 0;
		}
		
		transform.Translate(Vector3.right * x * Time.deltaTime * speed);
		transform.Translate(new Vector3(0, 0, 1) * z * Time.deltaTime * speed);
		
		//boundary
		if(transform.position.x > bound) transform.Translate(Vector3.right * (bound - transform.position.x));
		if(transform.position.x < bound * -1) transform.Translate(Vector3.right * ((bound * -1) - transform.position.x));
		if(transform.position.z > bound) transform.Translate(new Vector3(0, 0, 1) * (bound - transform.position.z));
		if(transform.position.z < bound * -1) transform.Translate(new Vector3(0, 0, 1) * ((bound * -1) - transform.position.z));
    }
}
