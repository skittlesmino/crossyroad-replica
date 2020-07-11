
using UnityEngine;
using UnityEngine.UI;
public class scoreManager : MonoBehaviour
{
    public Transform player;
    public Text Score;

    void Update()
    {
        if(int.Parse(Score.text) < Mathf.Floor(player.position.x)) 
        Score.text = Mathf.Floor(player.position.x).ToString("0");
    }
}
