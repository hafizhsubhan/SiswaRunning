using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    private controll player;
	private pause paused;


    void Start()
    {
        player = FindObjectOfType<controll>();
		paused = FindObjectOfType<pause> ();

    }

    public void LeftArrow()
    {
        player.moveright = false;
        player.moveleft = true;
    }
    public void RightArrow()
    {
        player.moveright = true;
        player.moveleft = false;
    }

    public void UpArrow()
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

	public void unPause()
	{
		paused.paused = false;
	}

	public void restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}


