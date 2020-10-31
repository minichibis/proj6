/*Sam Carpenter
 *Lab 6
 *game manager on steroids
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class singleton : MonoBehaviour
{
	public static singleton instance;
	private string currentlvl;
	private bool paused = false;
	public GameObject pausemenu;
	
	public int objective = 5;
	public int coins;
	public bool gaming;
	
	public Text score;
	public Text win;
	
    private void Awake(){
        if (instance == null){
			instance = this;
			DontDestroyOnLoad(gameObject);
			pausemenu.SetActive(false);
			currentlvl = "Menu";
			score.enabled = false;
			win.enabled = false;
		} else{
			Destroy(instance.gameObject);
			instance = this;
			DontDestroyOnLoad(gameObject);
			pausemenu.SetActive(false);
			currentlvl = "Menu";
			score.enabled = false;
			win.enabled = false;
			Debug.Log("ERROR: second singleton");
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
			if(paused){
				unpause();
			} else{
				Time.timeScale = 0f;
				paused = true;
				pausemenu.SetActive(true);
			}
        }
		
		if(currentlvl == "Menu"){
			score.enabled = false;
			win.enabled = false;
			gaming = false;
		} else{
			score.enabled = true;
			score.text = coins.ToString();
			if(coins >= objective){
				win.enabled = true;
				win.text = "YOU WIN!";
			} else if(!gaming){
				win.enabled = true;
				win.text = "YOU LOSE!";
			} else{
				win.enabled = false;
				win.text = "";
			}
			
		}
    }
	
	public void load(string lvl){
		coins = 0;
		gaming = true;
		unpause();
		AsyncOperation ao = SceneManager.LoadSceneAsync(lvl, LoadSceneMode.Additive);
		if(ao == null){
			Debug.Log("ERROR: unable to load");
			return;
		}
		currentlvl = lvl;
	}
	
	public void unload(string lvl){
		AsyncOperation ao = SceneManager.UnloadSceneAsync(lvl);
		if(ao == null){
			Debug.Log("ERROR: unable to unload");
			return;
		}
	}
	
	public void unloadcurrent(){
		GameObject[] discs = GameObject.FindGameObjectsWithTag("Disc");
		foreach (GameObject d in discs){
			 Destroy(d);
		}
		AsyncOperation ao = SceneManager.UnloadSceneAsync(currentlvl);
		if(ao == null){
			Debug.Log("ERROR: unable to unload");
			return;
		}
	}
	
	public void unpause(){
		Time.timeScale = 1f;
		paused = false;
		pausemenu.SetActive(false);
	}
	
	public void setobjective(int o){
		objective = o;
	}
}
