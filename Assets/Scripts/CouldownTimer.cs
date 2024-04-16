using System.Collections;
using TMPro;
using UnityEngine;

namespace CarRacing
{
    public class CouldownTimer : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private float countdownDuration = 5f;
        [SerializeField]
        private float timeBetweenCoundown = 1f;

        [SerializeField]
        private PlayerInputController _input;
        [SerializeField]
        private GameObject _timer;

        private Animation _coundownAnimation;

        private void Start()
        {
            _coundownAnimation = GetComponent<Animation>();

            _input.enabled = false;
            StartCoroutine(StartCountdown());
        }

        private IEnumerator StartCountdown()
        {
            for(int i = (int)countdownDuration; i >= 1 ; i--)
            { 
               _text.text = i.ToString();
                PlayCountdownAnimation();
                yield return new WaitForSeconds(timeBetweenCoundown);
            }

            _text.text = "START";
            _input.enabled = true;
            
            yield return new WaitForSeconds(0.75f);
            
            _timer.SetActive(true);
            gameObject.SetActive(false);
        }

        private void PlayCountdownAnimation()
        {
            if(_coundownAnimation != null)
            {
                _coundownAnimation.Play();
            }
        }
    }
}
