using TMPro;
using UnityEngine;

namespace CarRacing
{
    public class YourNameComponent : MonoBehaviour
    {
        [SerializeField]
        AfterFinishComponent _afterFinish;

        [SerializeField]
        private TMP_InputField _name;
        
        public void OnClick_AcceptName()
        {
            _afterFinish.OpenLeaderboard(_name.text);
            gameObject.SetActive(false);
        }
    }
}
