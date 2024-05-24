using UnityEngine;

namespace SexyDu.Tool
{
    public class SafeAreaAnchor : MonoBehaviour
    {
        [SerializeField] private bool onEnableSet;
        private void OnEnable()
        {
            if (onEnableSet)
                Set();
        }

        public void Set()
        {
            var rectTransform = GetComponent<RectTransform>();
            var safeArea = Screen.safeArea;
            
            var minAnchor = safeArea.position;
            var maxAnchor = minAnchor + safeArea.size;

            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAnchor.x /= Screen.width;
            maxAnchor.y /= Screen.height;

            rectTransform.anchorMin = minAnchor;
            rectTransform.anchorMax = maxAnchor;
        }
    }
}