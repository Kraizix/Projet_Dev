using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public Sprite sprite;
    public float BPM;
    public GameObject _blue, _red;
    public int index = 0;
    public string CollisionCubename = "";
    public string currentCol = "Tile 0";
    public bool isMoveBallCollNew = false;
    public bool game = false;
    public float dist = 0.0f;
    public List<float> AccList = new List<float>();
    public Transform cam;
    public Text Acc;
    public Text countdown;
    public Text EndText;
    public bool TileHit = false;
    public bool auto;
    public bool noFail;
    [SerializeField] GameObject endMenu;
    


    void Start()
    {
        auto = PlayerPrefs.GetInt("auto",0) == 1;
        noFail = PlayerPrefs.GetInt("noFail",0) == 1;

    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        RotateAround();
        if (Input.anyKeyDown)
        {
            if(isMoveBallCollNew){
                Move();
            }
        }
        if(game){
            if(isMoveBallCollNew){
                    if(int.Parse(CollisionCubename.Split()[1])==int.Parse(currentCol.Split()[1])+1 && CollisionCubename != currentCol)
                    {
                        TileHit = true;
                    }
            }
            if(auto){
                if(Math.Abs(((dist-0.40f)/0.40f)*100) >=70f)
                {
                    Move();
                }
            }
            if(!isMoveBallCollNew  && TileHit){
                if(!noFail){
                    Acc.text = "Miss";
                    Acc.color = Color.red;
                    StartCoroutine(gameOver(0f));
                } else {
                    Move();
                }
            }
        }
    }

    private void RotateAround()
    {
        if (index == 0)
        {
            _blue.transform.RotateAround(_red.transform.position, Vector3.forward, -BPM * 6f * Time.deltaTime);
        }
        else
        {
            _red.transform.RotateAround(_blue.transform.position, Vector3.forward, -BPM * 6f * Time.deltaTime);
        }
    }

    IEnumerator Transition(){
        float transitionDuration = (60 / BPM)/2.6f;
        float t = 0f;
        Vector3 startingPos= cam.transform.position;
        while(t<1.0f){
            t += Time.deltaTime *(Time.timeScale/transitionDuration);
            if(index == 1){
                Vector3 target = _blue.transform.position;
                target.z = -10;
                cam.transform.position = Vector3.Lerp(startingPos,target,t);
                
            } else {
                Vector3 target = _red.transform.position;
                target.z = -10;
                cam.transform.position = Vector3.Lerp(startingPos,target,t);
            }
            yield return null;
        }
    }
    IEnumerator gameOver(float secs){
        yield return new WaitForSeconds(secs);
        EndText.text = "Game Over";
        endMenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;

    }
    public void Move()
    {
            if(game){
                if(int.Parse(CollisionCubename.Split()[1])<int.Parse(currentCol.Split()[1]) || int.Parse(CollisionCubename.Split()[1]) != int.Parse(currentCol.Split()[1])+1)
                {
                    return;
                }
            }
            var col = GameObject.Find(CollisionCubename);
            if (col.tag == "Portal"){
                Debug.Log("Salut");
                if (!game){
                    SceneManager.LoadScene("Level1");
                } else {
                    Debug.Log("Salut");
                    float TotalAcc = Queryable.Average(AccList.AsQueryable());
                    Debug.Log("TotalAcc: " + TotalAcc);
                    EndText.text = string.Format("Average Accuracy: {0}%", TotalAcc);
                    endMenu.SetActive(true);
                    AudioListener.pause =true;
                    Time.timeScale = 0f;
                }
                
            } else if (col.tag == "Create"){
                Debug.Log("Create");
                SceneManager.LoadScene("CreateLevel");
            }
            if(index == 0){
                _blue.transform.position = col.transform.position;
                _blue.GetComponent<TrailRenderer>().enabled=false; 
                _red.GetComponent<TrailRenderer>().enabled=true;
                if(game)
                    StartCoroutine(Transition());
                
            }
            else{
                _red.transform.position = col.transform.position;
                _blue.GetComponent<TrailRenderer>().enabled=true;
                _red.GetComponent<TrailRenderer>().enabled=false;
                if(game)
                    StartCoroutine(Transition());
            }
            if(game){
                float accuracy = Math.Abs(((dist-0.40f)/0.40f)*100);
                if(100>=accuracy && accuracy>=75){
                    Acc.text = "Perfect";
                    Acc.color = Color.green;
                    accuracy = 100f;
                } else if(75>accuracy && accuracy>=50){
                    Acc.text = "Great";
                    Acc.color = Color.yellow;
                    accuracy = 75f;
                } else if(50>accuracy && accuracy>=25){
                    Acc.text = "Good";
                    Acc.color = Color.blue;
                    accuracy = 50f;
                } else if(25>accuracy && accuracy>=0){
                    Acc.text = "Bad";
                    Acc.color = Color.red;
                    accuracy = 25f;
                }
                RectTransform rect = Acc.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector3(_blue.transform.position.x, _blue.transform.position.y,0);
                AccList.Add(accuracy);
                TileHit = false;
            }
            currentCol = CollisionCubename;
            index = (index + 1) % 2;
    } 
}

