using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class stage : MonoBehaviour {
    public Text S;
    public Text A;
    public Text B;
    public Text C;
    public Text D;
    public Text E;
    public Text mission;
    public Text mission1;
    float startTime;
    int fadeTime=5;
    Color alpha;
    public Image background;
    public Camera maincamera;
    public Camera anothercamera;
    Button res;
    Button home;
    public static int enemy;
    public Text enemies;
    public Text time;
    int game;
    const int stagestart = 0;
    const int stagegaming = 1;
    const int stagefinis = 2;
    float timer = 240f;
    float timerst = 0f;
    
	// Use this for initialization
	void Start () {
        S.enabled = false;
        A.enabled = false;
        B.enabled = false;
        C.enabled = false;
        D.enabled = false;
        E.enabled = false;
        game = stagestart;
        time.text = "残り：240秒";
        enemies.text = "撃破数:"+enemy+"/20";
        res = GameObject.Find("restart").GetComponent<Button>();
        home = GameObject.Find("home").GetComponent<Button>();
        res.gameObject.SetActive(false);
        home.gameObject.SetActive(false);
        anothercamera.enabled = false;
        maincamera.enabled = true;
        enemy = 0;
        background.enabled = false;
        startTime = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        switch (game)
        {
            case stagestart:
                timerst += Time.deltaTime;
                if (timerst > 5)
                {
                    
                    game = stagegaming;
                    alpha.a = 1.0f - (Time.time - startTime) / fadeTime;
                    GameObject.Find("sakusen").GetComponent<Image>().color = new Color(0, 0, 0, alpha.a);
                    mission.color = Color.clear;
                    mission1.color = Color.clear;
                }
                break;
            case stagegaming:

                timer -= Time.deltaTime;
                time.text = "残り:" + timer.ToString("f0") + "秒";
                if (timer < 0||enemy==16||sensyacar.hitpoint<=0)
                {
                    time.text = "残り:0秒";
                    game = stagefinis;
                }
                break;
            case stagefinis:
                res.gameObject.SetActive(true);
                home.gameObject.SetActive(true);
                maincamera.enabled = false;
                anothercamera.enabled = true;
                background.enabled = true;
                break;
                if (enemy >= 0 && enemy <= 4)
                {
                    E.enabled = true;
                }else if (enemy >= 5 && enemy <= 9)
                {
                    D.enabled = true;
                }else if (enemy >= 10 && enemy <= 11)
                {
                    C.enabled = true;
                }else if (enemy >= 12 && enemy <= 13)
                {
                    B.enabled = true;
                }else if (enemy >= 14 && enemy <= 15)
                {
                    A.enabled = true;
                }else if (enemy == 16)
                {
                    S.enabled = true;
                }
        }
	}
}
