using UnityEngine;

public class Point : MonoBehaviour
{
    public TextMesh textPoints;

    private int points;

    private void Start()
    {
        points = Random.Range(1, 6);
        textPoints.text = points.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerTail player))
        {
            for (int i = 0; i < points; i++)
            {
                player.AddTail();
            }
            Destroy(gameObject);
        }
    }
}
