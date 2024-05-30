using System;
using UnityEngine;
using TMPro;

namespace SexyDu.UGUI
{
    /// <summary>
    /// 팝업 InputField
    /// </summary>
    public class PopupInputField : MonoBehaviour
    {
        // Input field
        [SerializeField] private TMP_InputField inputField;
        // 설정된 워드
        private string text { get => inputField.text; }

        #region setter
        /// <summary>
        /// 초기 설정
        /// </summary>
        /// <returns></returns>
        public PopupInputField Initialize()
        {
            return this;
        }

        /// <summary>
        /// 초기 설정
        /// </summary>
        public PopupInputField Initialize(string text)
        {
            inputField.text = text;

            return Initialize();
        }

        /// <summary>
        /// InputField 선택
        /// </summary>
        public PopupInputField SelectInputField()
        {
            inputField.Select();

            return this;
        }

        /// <summary>
        /// 워드 결정 콜백 이벤트
        /// </summary>
        private Action<string> onDecided = null;
        public PopupInputField CallbackOnDecided(Action<string> onDecided)
        {
            this.onDecided = onDecided;

            return this;
        }

        /// <summary>
        /// 팝업 종료 이벤트
        /// </summary>
        private Action onClosed = null;
        public PopupInputField CallbackOnClosed(Action onClosed)
        {
            this.onClosed = onClosed;

            return this;
        }
        #endregion

        #region feature
        /// <summary>
        /// 현재 입력된 워드 결정
        /// </summary>
        private void Decide()
        {
            Decide(text);
        }

        /// <summary>
        /// 워드 결정
        /// </summary>
        private void Decide(string text)
        {
            onDecided?.Invoke(text);
        }

        /// <summary>
        /// 빈 워드 결정
        /// </summary>
        private void Clear()
        {
            Decide(string.Empty);
        }

        /// <summary>
        /// 팝업 종료
        /// </summary>
        public void Close()
        {
            onClosed?.Invoke();

            Destroy(gameObject);
            Destroy(this);
        }
        #endregion

        #region event on click
        /// <summary>
        /// 결정 버튼 클릭
        /// </summary>
        public void OnClickDecide()
        {
            Decide();

            Close();
        }

        /// <summary>
        /// 클리어 버튼 클릭
        /// </summary>
        public void OnClickClear()
        {
            Clear();

            Close();
        }

        /// <summary>
        /// 취소 버튼 클릭
        /// </summary>
        public void OnClickClose()
        {
            Close();
        }
        #endregion
    }
}