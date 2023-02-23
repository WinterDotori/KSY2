using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    Player player;
    public Enemy enemy;

    public Text txtScore; // 격추점수
    public Image[] Lifes; // Life 이미지

    void Start()
    {
    }

    void Update()
    {
        txtScore.text = GameManager.instance.gameScore.ToString();

        for (int i = 0; i < Lifes.Length; i++)
        {
            Lifes[i].enabled = false;
        }

        Player player = GameManager.instance.player.GetComponent<Player>();
        for (int i = 0; i < player.life; i++)
        {
            Lifes[i].enabled = true;
        }
    }
}
