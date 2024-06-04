using UnityEngine;

namespace SexyDu.InGameDebugger
{
    /// <summary>
    /// 아이템 콘솔 Handler
    /// </summary>
    public class ItemConsoleHandler : ConsoleHandler, IItemConsoleUIHandle
    {
        /// <summary>
        /// 초기 설정
        /// </summary>
        public override ConsoleHandler Initialize()
        {
            base.Initialize();

            return this;
        }

        [Header("ItemConsole")]
        [SerializeField] private ItemConsole itemConsole;
        protected override Console console => itemConsole;

        #region UI
        private IItemConsoleHandlerUI ui;
        protected override IConsoleHandlerUI BaseUI => ui;

        public void Connect(IItemConsoleHandlerUI ui)
        {
            this.ui = ui;
        }
        #endregion
    }
}