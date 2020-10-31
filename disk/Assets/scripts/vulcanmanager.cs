/*Sam Carpenter
 *Lab 6
 *same as discmanager but for vulcan
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vulcanmanager : MonoBehaviour
{
	public float speed = 10f;
	public float bound = 25f;
	private vulcandisc disc;
	
    void Start(){
		disc = new vulcandisc();
		disc.init(Random.Range(-1f, 1f), transform, gameObject);
	}
	
    void Update(){
		disc.step();
        transform.Translate(Vector3.right * disc.getx() * Time.deltaTime * speed);
		transform.Translate(new Vector3(0, 0, 1) * disc.getz() * Time.deltaTime * speed);
		
		//boundary
		if(transform.position.x > bound || transform.position.x < bound * -1 || transform.position.z > bound || transform.position.z < bound * -1) disc.onbounce();
    }
	
	private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
			disc.ontouchplayer();
		}
		
	}
}
