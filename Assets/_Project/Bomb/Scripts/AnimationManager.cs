using DG.Tweening;
using UnityEngine;

namespace _Project.Bomb.Scripts
{
    public class AnimationManager : MonoBehaviour
    {
        private const float BeepLightOn = 20F;
        private const float BeepLightOff = 0F;
        private const float BeepLightInterval = 0.23F;
        private const float BeepLightFadeDuration = 0.01F;
        
        private static readonly int IsBeeping = Animator.StringToHash("IsBeeping");
        
        [SerializeField] private Animator _animator;
        
        [Header("Beep Configuration")]
        [SerializeField] private AudioSource _beepAudioSource;
        [SerializeField] private Light _beepPointLight;

        public void ToggleBeep(bool isActive) => _animator.SetBool(IsBeeping, isActive);

        // Called in beep animation
        public void OnBeep()
        {
            PlayBeepSoundFX();
            PlayBeepLightFX();
        }

        private void PlayBeepSoundFX() => _beepAudioSource.Play();

        private void PlayBeepLightFX()
        {
            DOTween.Sequence()
                .Append(_beepPointLight.DOIntensity(BeepLightOn, BeepLightFadeDuration))
                .AppendInterval(BeepLightInterval)
                .Append(_beepPointLight.DOIntensity(BeepLightOff, BeepLightFadeDuration))
                .Play();
        }
    }
}