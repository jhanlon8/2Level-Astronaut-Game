using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScoreScene3 : MonoBehaviour
{
    public static int Score = 0;
    public static int items = 0;
    public static int itemsLeft = 4; //3 enemies and tthen count down

    string complete = "CONGRATS! YOU COMPLETED THE SCENE!";

    private GUIStyle fontSize;
    // Start is called before the first frame update
    void Start()
    {
        fontSize = new GUIStyle();
        fontSize.fontSize = 24;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 75, 120, 70), "Score: " + Score.ToString() + "\n\nItems Collected: " + items.ToString() + "\nItems Left: " + itemsLeft.ToString());

        //if score is greater than 400, tell the user they completed the Scene
        if (Score >= 400)
        {
            GUI.Box(new Rect(200, 150, 400, 200), complete, fontSize);
        }

    }
}
