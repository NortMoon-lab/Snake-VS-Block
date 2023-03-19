using UnityEngine;
using UnityEngine.UI;

public class LevelNumberText : MonoBehaviour
{
    public Text Text;
    public int plus;
    public Game Game;

    private void Start()
    {
        Text.text = (Game.LevelIndex + plus + 1).ToString();
    }
}
