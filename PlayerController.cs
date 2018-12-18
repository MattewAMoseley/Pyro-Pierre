using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour 
{
	private Animator anim;
    int scoreInt;
    Vector2 startingPosPlayer;
    int lvlId;
    const int numLvls = 2;
    GameObject lvl;
    void Start()
    {
        startingPosPlayer = new Vector2(-17.0F, 9.0f);
        anim = gameObject.GetComponent<Animator>();
        scoreInt = 0;
        lvlId = 0;
        reloadLevel();
    }
    void reloadLevel()
    {
        lvlId++;
        if (lvl != null) {
            Destroy(lvl);
        }
        if (lvlId <= numLvls)
        {
            lvl = Instantiate(Resources.Load("Levels/Level" + lvlId.ToString(), typeof(GameObject))) as GameObject;
            gameObject.transform.position = startingPosPlayer;
        }
        else
        {
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
        }
    }
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = gameObject.transform.position;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			position.y += .1f;
			gameObject.transform.position = position;
			
			//anim.enabled = true;
			
			if(gameObject.transform.rotation != Quaternion.Euler(0, 0, 0))
			{
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			}

			anim.enabled = true;

		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			position.y -= .1f;
			gameObject.transform.position = position;

			if(gameObject.transform.rotation != Quaternion.Euler(0, 0, 180))
			{
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
			}

			anim.enabled = true;
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			position.x -= .1f;
			gameObject.transform.position = position;
			
			//anim.enabled = true;
			
			if(gameObject.transform.rotation != Quaternion.Euler(0, 0, 90))
			{
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
			}
			
			anim.enabled = true;
		} 
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			position.x += .1f;
			gameObject.transform.position = position;
			
			//anim.enabled = true;
			
			if(gameObject.transform.rotation != Quaternion.Euler(0, 0, 270))
			{
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 270);
			}
			
			anim.enabled = true;
		}

		if(Input.anyKey == false)
		{
				anim.enabled = false;
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Fuse")
        {
            //Score code
            GameObject score = GameObject.FindGameObjectWithTag("Score");
			TextMesh scoreTm = (TextMesh)score.GetComponent(typeof(TextMesh));

			//Get distance between fuse and TNT
			Vector3 fusePos = coll.gameObject.transform.position;
			GameObject tnt = GameObject.FindGameObjectWithTag("TNT");
			Vector3 tntPos = tnt.transform.position;
			float distance = Vector3.Distance(fusePos, tntPos);

			//Change score based on distance
			if(distance >= 20)
			{
				scoreInt += 500;
			}
			else if (distance < 20 && distance > 10)
			{
				scoreInt += 250;
			}
			else
			{
				scoreInt += 100;
			}

			scoreTm.text = scoreInt.ToString();

            //Reset level
            reloadLevel();
        }
        //these collieders are used for fuse game logic
		if(coll.gameObject.tag == "GoUp" || coll.gameObject.tag == "GoDown" || coll.gameObject.tag == "GoLeft" || coll.gameObject.tag == "GoRight")
		{
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
		}
	}
}
