/*Sam Carpenter
 *Lab 6
 *makes the coin operate with the world
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinmanager : MonoBehaviour
{
	private basiccoin coin;
	public GameObject d;
	
    void Start(){
		coin = new basiccoin();
		coin.init(d, transform, gameObject);
	}
	
    void Update(){
        
    }
	
	private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
			coin.ontouchplayer();
		}
		
	}
}