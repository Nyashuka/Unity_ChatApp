using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIModule
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private UIDocument uiDocument;
        [SerializeField] private VisualTreeAsset chatListItem;

        private void Start()
        {
            var chatItems = uiDocument.rootVisualElement.Q<ListView>("chatItemsListView");

            List<string> names = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                names.Add("John Depth " + i);
            }

            TextField textField;
            Action<VisualElement, int> bindItem = (e, i) => e.Q<Label>("chatName").text = names[i];

            chatItems.Q<ScrollView>().verticalScrollerVisibility = ScrollerVisibility.Hidden;
            chatItems.Q<ScrollView>().horizontalScrollerVisibility = ScrollerVisibility.Hidden;
            
            chatItems.makeItem = () => chatListItem.Instantiate();
            chatItems.bindItem = bindItem;
            chatItems.itemsSource = names;

            uiDocument.rootVisualElement.Q<TextField>("messageInput")
                .RegisterCallback<KeyDownEvent>(OnExecuteCommandEventMessageInput);
        }

        private void OnExecuteCommandEventMessageInput(KeyDownEvent evt)
        {
            // if (evt.keyCode == KeyCode.Return)
            // {
            //     var inputPanel = uiDocument.rootVisualElement.Q<VisualElement>("inputPanel");
            //
            //
            //     Debug.Log(inputPanel.resolvedStyle.height);
            //     inputPanel.style.height = new StyleLength(250);
            //     Debug.Log(inputPanel.resolvedStyle.height);
            // }
        }
    }
}