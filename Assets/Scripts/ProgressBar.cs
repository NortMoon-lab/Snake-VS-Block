using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform Finish;
    public Slider Slider;
    public float AcceptableFinishPlayerDistance = 1f;

    private float _startZ;
    private float _maximumReachedZ;

    private void Start()
    {
        _startZ = Player.transform.position.z;
    }

    private void Update()
    {
        _maximumReachedZ = Mathf.Max(_maximumReachedZ, Player.transform.position.z);
        float finishZ = Finish.position.z;
        float t = Mathf.InverseLerp(_startZ, finishZ + AcceptableFinishPlayerDistance, _maximumReachedZ);
        Slider.value = t;
    }
}
