using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private controll player;
	private pause paused;
	private LoadScene ld;
	private GameScore sv;
	public string sceneToLoad;
	public GameObject en;
	int scene;


    void Start()
    {
        player = FindObjectOfType<controll>();
		paused = FindObjectOfType<pause> ();
		ld = FindObjectOfType<LoadScene> ();
		sv = FindObjectOfType<GameScore> ();
    }

	void Update()
	{
		if(Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.LeftControl)){
			File.Delete (Application.persistentDataPath + "/scoredata.dat");
			File.Delete (Application.persistentDataPath + "/scenedata.dat");
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
		Debug.Log (SceneManager.GetActiveScene ().buildIndex);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void play()
	{
		if (File.Exists (Application.persistentDataPath + "/scenedata.dat")) {
			Load ();
			SceneManager.LoadSceneAsync (scene);
		} else {
			SceneManager.LoadSceneAsync (2);
		}
	}

	public void Load(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/scenedata.dat", FileMode.Open);
	
		SceneData data = (SceneData)bf.Deserialize (file);
		file.Close ();

		scene = data.sceneToLoad;
	}

	public void enter()
	{
		ld.inZone = true;
	}

	public void load()
	{
		sv.saveScore = true;
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


