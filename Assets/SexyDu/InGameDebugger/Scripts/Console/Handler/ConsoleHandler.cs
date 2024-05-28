using System;
using UnityEngine;

namespace SexyDu.InGameDebugger
{
    public abstract partial class ConsoleHandler : MonoBehaviour, IConsoleUIHandle, IActivable, IClearable
    {
        // 콘솔
        protected abstract Console console { get; }
        // 로그 수집 서브젝트
        public IConsoleLogSubject ConsoleLogSubject { get => console; }
        // 로그 수집 상태 : IConsoleUIHandle
        public bool Playing { get { return console.Playing; } }

        /// <summary>
        /// 초기 설정
        /// </summary>
        public virtual ConsoleHandler Initialize()
        {
            console.Initialize();
            console.Play();

            return this;
        }

        /// <summary>
        /// 클리어
        /// : IClearable
        /// </summary>
        public virtual void Clear()
        {
            console.Clear();
        }

        /// <summary>
        /// 콘솔 로깅 중지 설정
        /// : IConsoleUIHandle
        /// </summary>
        public void PauseConsole(bool pause)
        {
            if (pause)
                console.Pause();
            else
                console.Play();
        }

        /// <summary>
        /// 콘솔 로그 클리어
        /// : IConsoleUIHandle
        /// </summary>
        public void ClearConsole()
        {
            console.Clear();
        }

        #region Activation
        /// <summary>
        /// 활성화
        /// : IActivable
        /// </summary>
        public void Activate()
        {
            SetActive(true);

            NotifyActivation();
        }

        /// <summary>
        /// 비활성화
        /// : IConsoleUIHandle
        /// </summary>
        public void Inactivate()
        {
            SetActive(false);

            NotifyActivation();
        }
        #endregion

        #region Activation Log Type
        public void ActivateLogType(params LogType[] logTypes)
        {
            console.ActivateLogType(logTypes);
        }

        public void InactivateLogType(params LogType[] logTypes)
        {
            console.InactivateLogType(logTypes);
        }
        #endregion

        #region ObjectCache
        [Header("ObjectCache")]
        [SerializeField] private GameObject gameObjectCache;
        private GameObject GameObjectCache { get => gameObjectCache; }
        [SerializeField] private RectTransform rectTransformCache;
        private RectTransform RectTransformCache { get => rectTransformCache; }

        private void SetActive(bool active)
        {
            GameObjectCache.SetActive(active);
        }
        #endregion
    }
}