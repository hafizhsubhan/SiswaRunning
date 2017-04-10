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
	public GameObject tutorial;
	int scene;


    void Start()
    {
        player = FindObjectOfType<controll>();
		paused = FindObjectOfType<pause> ();
		ld = FindObjectOfType<LoadScene> ();
		sv = FindObjectOfType<GameScore> ();
		tutorial = GameObject.Find ("tutor");
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

	public void nextstage()
	{
		sv.saveScore = true;
		SceneManager.LoadScene (ld.load);
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
		scene = SceneManager.GetActiveScene ().buildIndex + 1;
		SaveScene ();
		SceneManager.LoadScene ("menu");
	}

	public void SaveScene(){ 

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/scenedata.dat");

		SceneData data = new SceneData ();
		data.sceneToLoad = scene;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void tutup()
	{
		tutorial.SetActive (false);
		Time.timeScale = 1;
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


[System.Serializable]
class SceneData{
	public int sceneToLoad;
}

