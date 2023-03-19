using System.Collections.Generic;
using UnityEngine;

public class PlayerTail : MonoBehaviour
{
    public Transform PlayerHead;
    public Transform TailModel;
    public float TailDiameter;
    public int Length;
    public Game game;

    public TextMesh PointsText;
    public NumberPoints numberPoints;

    private List<Transform> partsTail = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        positions.Add(PlayerHead.position);
    }
    void Start()
    {
        for (int i = 0; i < game.Points; i++)
        {
            AddTail();
        }
    }

    void Update()
    {
        float distance = ((Vector3)PlayerHead.position - positions[0]).magnitude;
        
        if (distance > TailDiameter)
        {
            Vector3 direction = ((Vector3)PlayerHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * TailDiameter);
            //positions.Insert(0, PlayerHead.position);
            positions.RemoveAt(positions.Count - 1);
        
            distance -= TailDiameter;
        }
        
        for (int i = 0; i < partsTail.Count; i++)
        {
            partsTail[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / TailDiameter);
        }
    }

    public void AddTail()
    {
        Transform Tail = Instantiate(TailModel, positions[positions.Count - 1], Quaternion.identity, transform);
        partsTail.Add(Tail);
        positions.Add(Tail.position);

        Length++;
        PointsText.text = Length.ToString();
    }

    public void RemoveTail()
    {
        Destroy(partsTail[0].gameObject);
        partsTail.RemoveAt(0);
        positions.RemoveAt(1);

        Length--;
        PointsText.text = Length.ToString();
        numberPoints.AddPoint();
    }

    public void Defeat()
    {
        game.PlayerDefeat();
    }

    public void ReachFinish()
    {
        game.OnPlayerReachedFinish(Length);
    }
}
