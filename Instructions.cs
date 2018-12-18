using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    //project created with historic GUI component methods
    private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load("TitleGUI") as GUISkin;
	}
    //project created with historic GUI component methods
    //alt method for remake - make a canvas item and make this into a function on it 
    void OnGUI()
	{
		const int buttonWidth = 450;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height - 80, buttonWidth, buttonHeight), "Return to Title"))
		{
            SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
            /*
            Obsoleted
            Application.LoadLevel("TitleScreen");
            */
        }
    }
}