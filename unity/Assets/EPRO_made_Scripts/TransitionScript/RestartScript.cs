using UnityEngine;
using System.Collections;

public class RestartScript : MonoBehaviour
{
    GameObject Monster;
    GameObject Player;

    void Start()
    {
        Monster = GameObject.Find("Monster");
        Player = GameObject.Find("2DCharacter");
    }

    public void Restart()
    {
        RestartMonster();
        RestartPlayer();
    }

    public void RestartMonster()
    {
        Monster.SetActive(false);
    }

    public void RestartPlayer()
    {
        Player.transform.position = new Vector2(0, 0);
    }
}
