using UnityEngine;

public class Finish : MonoBehaviour
{
    public ParticleSystem _ParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerTail player))
        {
            _ParticleSystem.Play();
            player.ReachFinish();
        }
    }
}
