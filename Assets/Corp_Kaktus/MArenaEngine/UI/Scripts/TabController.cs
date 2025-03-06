using UnityEngine;

namespace Corp_Kaktus.UI.Scripts
{
    public class TabController : MonoBehaviour
    {
        public int currentTabId;

        public void SetTab() => UpdateTabState();

        public void SetTabByIndex(int tabId) { currentTabId = tabId; UpdateTabState(); }

        public void SetTabByName(string tabName)
        {
            for (var childIndex = 0; childIndex < transform.childCount; childIndex++)
                if (tabName == transform.GetChild(childIndex).name)
                    SetTabByIndex(childIndex);
        }

        private void Start()
        {
            UpdateTabState();
        }

        private void OnValidate()
        {
            UpdateTabState();
        }

        private void UpdateTabState()
        {
            var successFullyFind = false;


            for (var index = 0; index < transform.childCount; index++)
            {
                var child = transform.GetChild(index);
                if (index == currentTabId)
                {
                    successFullyFind = true;
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }

            if (!successFullyFind)
            {
                Debug.LogWarning($"Can't found tab with index:{currentTabId}");
            }
        }
    }
}