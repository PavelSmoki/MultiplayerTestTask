using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class LoadingText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _loadingLabel;

        private float _delay;
        
        private void Update()
        {
            _delay += Time.deltaTime;

            if (_delay <= 0.5f)
            {
                _loadingLabel.text = "Loading.";
            }

            if (_delay >= 1f)
            {
                _loadingLabel.text = "Loading..";
            }

            if (_delay >= 1.5f)
            {
                _loadingLabel.text = "Loading...";
            }

            if (_delay >= 2.5f)
            {
                _delay = 0f;
            }
        }
    }
}