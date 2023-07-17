using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlowerWateringSystem : MonoBehaviour
{


    [Header("Zone Parameters")]
    [SerializeField] private int YellowZoneEnd;
    [SerializeField] private int RedZoneStart;

    [Header("OutComponents")]
    [SerializeField] private Slider _flowerWaterIndicatorSlider;
    [SerializeField] private Animator _poutButtonAnimator;
    [SerializeField] private FW_ParticleSpawner _patspawner;


    [SerializeField] private AudioClip[] _poutSound;

    private float FlowerWaterIndicatorValue;


    private Animator _indicatorAnimator;
    private AudioSource _audioSource;

    private bool IsAbleToWatering = true;


    private void Start()
    {
        _indicatorAnimator = _flowerWaterIndicatorSlider.GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (IsAbleToWatering)
        {
            FlowerWaterIndicatorValue = _flowerWaterIndicatorSlider.value;
        }
    }


    public void Pour()
    {
        if (IsAbleToWatering)
        {
            IsAbleToWatering = false;

            _indicatorAnimator.enabled = false;
            _poutButtonAnimator.Play("Off");

            _flowerWaterIndicatorSlider.value = FlowerWaterIndicatorValue;
            StartCoroutine(ToNextPourCoolDown());


            if (FlowerWaterIndicatorValue > RedZoneStart)
            {
                //Worst Pour
                _patspawner.ThrowParticlesEmoji(0);
                _audioSource.PlayOneShot(_poutSound[0]);
            }
            else if (FlowerWaterIndicatorValue < YellowZoneEnd)
            {
                //Bad Pour
                _patspawner.ThrowParticlesEmoji(1);
                _audioSource.PlayOneShot(_poutSound[1]);
            }
            else
            {
                //Good Pour
                _patspawner.ThrowParticlesEmoji(2);
                _audioSource.PlayOneShot(_poutSound[2]);
            }
        }
    }


    private IEnumerator ToNextPourCoolDown()
    {
        yield return new WaitForSecondsRealtime(10);
        IsAbleToWatering = true;

        _poutButtonAnimator.Play("On");
        _indicatorAnimator.enabled = true;
    }
}
