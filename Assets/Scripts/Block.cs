using UnityEngine;

public class Block : MonoBehaviour
{
    public int hp;
    public TextMesh hpText;

    private float timer;

    private void Start()
    {
        int x = Random.Range(1, 26);
        if (hp == 0)
            SetHp(x);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.TryGetComponent(out PlayerTail player))
        {
            timer += Time.deltaTime;
            if (timer <= 0.06f) return;
            timer = timer - 0.06f;

            if (collision.contacts[0].normal.z != 1) return;

            if (hp <= 0)
            {
                Destroy(gameObject);
                return;
            }

            if (player.Length > 0)
            {
                player.RemoveTail();
                hp--;
                hpText.text = hp.ToString();
            }
            else
            {
                player.Defeat();
            }
        }
    }

    public void SetHp(int i)
    {
        hp = i;
        hpText.text = hp.ToString();

        float n = (i / 50f) + 0.5f;
        Renderer blockRender = GetComponent<Renderer>();
        blockRender.material.color = Color.HSVToRGB(n, 0.88f, 0.80f);
    }
}
