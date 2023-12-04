using TMPro;
using UnityEngine;

namespace Assets.Scripts.GAME.UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI playerCurrentHealthText;

        public TextMeshProUGUI PlayerCurrentHealthText => playerCurrentHealthText;
    }
}
