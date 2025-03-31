using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamePlayer : MonoBehaviour
{
    //����
    public string PlayerName; // ���� - string
    public int Score; // ���� - int
    public int Hp;
    public float GameTimer; // ���� -  float(�Ҽ��� o)
    public bool isPlaying; //�³� Ʋ���� true false

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!isPlaying)
        {
            Debug.Log("������ �������ϴ�!");
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
