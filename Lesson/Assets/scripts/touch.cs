using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private controll player;
	private pause paused;
	private LoadScene ld;
	public string sceneToLoad;
	public GameObject en;


    void Start()
    {
        player = FindObjectOfType<controll>();
		paused = FindObjectOfType<pause> ();
		ld = FindObjectOfType<LoadScene> ();
    }

	void Update()
	{
		if(Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftControl)){
			File.Delete (Application.persistentDataPath + "/playerdata.dat");
			Debug.Log ("Save Data Deleted!");
		}
	}

    public void LeftArrow() //tombol kiri
    {
        player.moveright = false;
        player.moveleft = true;
    }
    public void RightArrow() //tombol kanan
    {
        player.moveright = true;
        player.moveleft = false;
    }

    public void UpArrow() //tombol atas
    {
		player.jump = true;
    }

    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;
    }

    public void ReleaseUpArrow()
    {
		player.jump = false;
    }

	public void pause()
	{
		paused.paused = true;
	}
		
	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void play()
	{
		SceneManager.LoadScene ("gerbang");
	}

	public void enter()
	{
		ld.inZone = true;
	}

	public void load()
	{
		SceneManager.LoadScene (sceneToLoad);
	}

	public void about()
	{
		SceneManager.LoadScene ("about");
	}

	public void cont()
	{
		SceneManager.LoadScene ("gerbang");
	}

	public void exit()
	{
		player.exit = true;
		SceneManager.LoadScene ("menu");
	}

	public void tutup()
	{
		en = GameObject.FindGameObjectWithTag ("pelajaran");
		en.SetActive (false);
	}


	public void exitD()
	{
		SceneManager.LoadScene ("menu");
	}

	public void quit()
	{
		Application.Quit ();
	}

}


