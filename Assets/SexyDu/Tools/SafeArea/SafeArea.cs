using UnityEngine;

namespace SexyDu.Tool
{
    public class SafeArea : MonoBehaviour
    {
        [SerializeField] private RectTransform target;
        public void Set(Canvas canvas)
        {
            Set(canvas.scaleFactor);
        }

        public void Set(float scaleFactor)
        {
            Vector2 safeAreaSize = Screen.safeArea.size;

#if true
            Vector2 offsetMin = Screen.safeArea.position;
            Vector2 offsetMax = new Vector2(
                Screen.width - safeAreaSize.x - offsetMin.x,
                Screen.height - safeAreaSize.y - offsetMin.y
                );

            target.offsetMin = offsetMin / scaleFactor;
            target.offsetMax = -offsetMax / scaleFactor;
#else
            Vector2 safeAreaPosition = Screen.safeArea.position;

            float left = safeAreaPosition.x > 0f ? safeAreaPosition.x : 0f;
            float bottom = safeAreaPosition.y > 0f ? safeAreaPosition.y : 0f;

            float right = Screen.width - safeAreaSize.x - left;
            float top = Screen.height - safeAreaSize.y - bottom;

            target.offsetMin = new Vector2(left, bottom) / scaleFactor;
            target.offsetMax = new Vector2(-right, -top) / scaleFactor;
#endif
        }
    }
}