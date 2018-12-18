using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
public class FuseController : MonoBehaviour {

    enum direction { up, down, left, right};
    direction state;
    Vector2 startingPos;

    //Levels will be built around this constant speed value (determined via trial and error)
    const float SPEED = .0195f;

    void Start () {
        state = direction.right;
        startingPos = new Vector2(-14.0F, -11.0f);
        gameObject.transform.position = startingPos;
        gameObject.SetActive(true);
    }
	
	// Update is called once per frame and will always be used to trigger the flame's movement
	void Update () {
		Vector2 position = gameObject.transform.position;
        
        switch (state)
        {
            case direction.up:
                position.y += SPEED;
                break;
            case direction.down:
                position.y -= SPEED;
                break;
            case direction.left:
                position.x -= SPEED;
                break;
            case direction.right:
                position.x += SPEED;
                break;
            default:
                break;
        }
			
		gameObject.transform.position = position;

		
	}
	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            gameObject.transform.position = startingPos;
        }
        if (coll.gameObject.tag == "TNT")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("GameOver");
            */
        }
        //This functionality is not being utilized presently but generating a level prefab with directional objects can be utilized to create unique fuse paths. 
        else
        {
            if (coll.gameObject.tag == "GoUp")
            {
                state = direction.up;
            }
            if (coll.gameObject.tag == "GoDown")
            {
                state = direction.down;
            }
            if (coll.gameObject.tag == "GoLeft")
            {
                state = direction.left;
            }
            if (coll.gameObject.tag == "GoRight")
            {
                state = direction.right;
            }
            //Triggered last to allow physics to be utilized for identifying the above conditions only and not applying physics
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
        }
        
    }
}
