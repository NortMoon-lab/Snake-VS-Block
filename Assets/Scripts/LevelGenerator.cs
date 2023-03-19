using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform barrier;
    public GameObject Block;
    public GameObject Point;
    public GameObject Borrder;
    public Transform Finish;
    public float StartDistance;
    public float Distance;
    public int min;
    public int max;
    public Game Game;

    private int num;

    private void Awake()
    {
        min += Game.LevelIndex * 3;
        max += Game.LevelIndex * 3;

        int ElenmenCount = Random.Range(min, max);

        barrier.localScale = new Vector3(1, 1, ElenmenCount * (Distance + 1) + StartDistance);
        Finish.localPosition = new Vector3(0, -1, ElenmenCount * (Distance + 1) + StartDistance - 10);

        for (int i = 1; i < ElenmenCount; i++)
        {
            num++;
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                if (num > 2)
                {
                    for (int e = 0; e < 5; e++)
                    {
                        GameObject element = Instantiate(Block, transform);
                        element.transform.localPosition = new Vector3(e * 2.5f - 5f, 0, Distance * i + StartDistance);
                    }
                    num = 0;
                    continue;
                }
            }


            for (int e = 0; e < 5; e++)
            {
                int Rand = Random.Range(0, 4);

                if (Rand == 0)
                {
                    GameObject element = Instantiate(Block, transform);
                    element.transform.localPosition = new Vector3(e * 2.5f - 5f, 0, Distance * i + StartDistance);
                    element.GetComponent<Block>().SetHp(Random.Range(1, 6));
                }
                else if (Rand == 1)
                {
                    GameObject element = Instantiate(Point, transform);
                    element.transform.localPosition = new Vector3(e * 2.5f - 5f, 0, Distance * i + StartDistance);
                }
            }

            for (int e = 0; e < 4; e++)
            {
                int Rand = Random.Range(0, 4);

                if (Rand == 0)
                {
                    GameObject element = Instantiate(Borrder, transform);
                    element.transform.localPosition = new Vector3(e * 2.5f - 3.75f, 0, Distance * i + StartDistance - 5f);
                }
            }
        }
    }
}
