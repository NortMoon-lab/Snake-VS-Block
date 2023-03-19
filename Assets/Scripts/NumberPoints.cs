using UnityEngine;
using UnityEngine.UI;

public class NumberPoints : MonoBehaviour
{
    public Text Text;

    private int Points;

    public void AddPoint()
    {
        Points++;
        Text.text = Points.ToString();
    }
}
