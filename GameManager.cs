using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{

    string NickName = "";
    int Score = 0;
    string GameTime;
    string gameId = "Super Ninja Dude";

    public bool gameHasEnded = false;

    public InputField ip;
    public GameObject completLvl;
    public GameObject lvlcompName;
    public GameObject timebord;
    public GameObject scorebord;

    [SerializeField] private Text name;
    [SerializeField] private Text time;
    [SerializeField] private Text scoreTxt;
    public float restartDelay = 3f;

    public Text timeCounter;
    private TimeSpan timePlayed;
    private bool timerGoing;
    private float elapsedTime;



    public void addScore(int point)
    {
        Score += point;
        Debug.Log("score is " + Score);
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void saveName()
    {
        NickName = ip.text;
        PlayerPrefs.SetString("nickname", NickName);
        Debug.Log("name is" + NickName);
    }

    void PostScore() => StartCoroutine(PostData_Coroutine());
    /*{
        // posting magic
        NickName = PlayerPrefs.GetString("nickname");
        /*NickName
        Score
        GameTime
        Date
        Debug.Log("Score" + NickName + Score + GameTime  + gameId+ "have been posted");
    }*/

   /* class jsonObj
    {
        
    } */


    IEnumerator PostData_Coroutine()
    {
        

        string uri = "https://best-playz-heroku-backend.herokuapp.com/highscore";
        string sScore = Score.ToString();
        string r = NickName + gameId + sScore + GameTime;

        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=nickname&field2=gameId&field3=score&field4=time"));
        formData.Add(new MultipartFormDataSection("nickname", NickName));
        formData.Add(new MultipartFormDataSection("gameId", gameId));
        formData.Add(new MultipartFormDataSection("score", sScore));
        formData.Add(new MultipartFormDataSection("time", GameTime));

        UnityWebRequest www = UnityWebRequest.Post(uri, formData);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
            Debug.Log(www.isNetworkError);
        Debug.Log(www.isHttpError);

        /*
        WWWForm form = new WWWForm();
        String jsonString = JsonUtility.ToJson(r, true);
        form.AddField("x", jsonString);

        WWW www = new WWW(uri, form);
        Debug.Log(www);
        yield return null;
       */


        /*  WWWForm form = new WWWForm();
        WWWForm f2 = new WWWForm();

        string fm = "{"+NickName + gameId + Score.ToString() + GameTime +"}";
        //string jsonD = JsonUtility.ToJson(fm);
       // byte[] postD = System.Text.Encoding.ASCII.GetBytes(jsonD);

      //  String postString = NickName + Score.ToString() + GameTime + gameId;
      String jS = JsonUtility.ToJson (postString,true);
         form.AddField("Nickname", fm);
        Debug.Log("post s" + fm);

         using(UnityWebRequest request = UnityWebRequest.Post(uri, form))
         {
             yield return request.SendWebRequest();
             if (request.isNetworkError || request.isHttpError)
                 Debug.Log(request.isNetworkError);
            Debug.Log(request.isHttpError);

        }*/

    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }


    public void CompleteLevel()
    {
        var Tspand = TimerController.instance.EndTimer();
        GameTime = Tspand.ToString(@"mm\:ss\:fff");
        if(Tspand.TotalSeconds < 10)
        {
            Score *= 5;
        }
        else if(Tspand.TotalSeconds < 20)
        {
            Score *= 4;
        }
        else if (Tspand.TotalSeconds < 30)
        {
            Score *= 3;
        }
        else if (Tspand.TotalSeconds < 45)
        {
            Score *= 2;
        }
        NickName = PlayerPrefs.GetString("nickname");
        Debug.Log("Lvlcomplett");
        completLvl.SetActive(true);

        name.text = "NickName" +" : "+ NickName;
        time.text = "Time" + " : " + GameTime;
        scoreTxt.text = "Score" + " : " + Score;
    }
   
    public void EndGame()
    {
        if(gameHasEnded == false)

        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }

    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
