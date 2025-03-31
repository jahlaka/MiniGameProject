using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    //숫자
    public string PlayerName; // 문자 - string
    public int Score; // 숫자 - int
    public int Hp;
    public float GameTimer; // 숫자 -  float(소수점 o)
    public bool isPlaying; //맞냐 틀리냐 true false

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!isPlaying)
        {
            Debug.Log("게임이 끝났습니다!");
            return;
        }


        GameTimer = GameTimer - Time.deltaTime;
        if (GameTimer < 0 )
        {
            isPlaying = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        bool isEnemy = other.gameObject.tag == "Enemy";
        bool isItem = other.gameObject.tag == "Item";

        if (isEnemy)
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;

            //-1 < 0
            // < <=
            // > >=
            if (Hp <= 0 )
            {
                isPlaying=false;
            }

           // if hp <= 0 -isPlaying = false
        }

        if (isItem)
        {
            Debug.Log("Item Check");
            
            // 0 = 0 + 1
            Score = Score + 1;
        }

        
        Destroy(other.gameObject);
    }

}
