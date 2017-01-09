using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using SuperApi;

public class SuperAPITest : MonoBehaviour 
{
	public void OnGUI()  
	{
		string debugStr = "Initialized: " + Kongregate.IsInitialized().ToString() + "\n";
		debugStr = debugStr + "UserId: " + Kongregate.GetUserId() + "\n";
		debugStr = debugStr + "UserName: " + Kongregate.GetUserName() + "\n";
		debugStr = debugStr + "GameAuthToken: " + Kongregate.GetGameAuthToken() + "\n";
		debugStr = debugStr + "Logs:\n" + Kongregate.GetLog();
		GUIStyle style = new GUIStyle();
		style.wordWrap = true;
		style.stretchHeight = false;
		style.stretchWidth = false;
		GUI.Box(new Rect(10, 10, 500, 500), debugStr, style);
	}
	
	public InputField statNameInput;
	public InputField statValueInput;
	public InputField itemIdInput;
	public EventTrigger[] useItemInstanceEvents;
	public Button[] useItemInstanceButtons;
	public Text[] useItemInstanceButtonTexts;
	public InputField messageInput;
	public InputField nameInput;
	public InputField feedMessageInput;
	public InputField shoutMessageInput;
	public InputField showTabNameInput;
	public InputField showTabSizeInput;
	public Text messageReceivedText;
	public Text userDataText;
	
	void Start()
	{
		Kongregate.Initialize();
		RefreshUseItemList(new ItemInstance[0]);
	}
	
	public void SubmitStatistic()
	{
		Kongregate.SubmitStatistic(statNameInput.text, statValueInput.text);
	}
	
	public void ShowTab()
	{
		Kongregate.ShowCustomTab(showTabNameInput.text, showTabNameInput.text, double.Parse(showTabSizeInput.text));
	}
	
	public void CloseTab()
	{
		Kongregate.CloseCustomTab();
	}
	
	public void DisplayCanvasText()
	{
		Kongregate.DisplayCanvasText();
	}
	
	public void DisplayMessage()
	{
		Kongregate.DisplayMessage(messageInput.text, nameInput.text);
	}
	
	public void AddMessageListener()
	{
		Kongregate.AddMessageReceivedListener(OnPlayerMessageReceived);
	}
	
	public void ReloadKreds()
	{
		Kongregate.ShowMobileReloadKredsDialog();
	}
	
	public void ShowFeedPostBox()
	{
		Kongregate.ShowFeedPostBoxWithImage(feedMessageInput.text, "http://www.keverse.com/uploads/6/9/2/3/69239759/471320.png?332");
	}
	
	public void ShowShoutBox()
	{
		Kongregate.ShowShoutBox(shoutMessageInput.text);
	}
	
	public void GetPurchasedItems()
	{
		Kongregate.RequestUserItemList(OnGetPurchasedItems);
	}
	
	public void OnPlayerMessageReceived(string result)
	{
		messageReceivedText.text = result;
	}
	
	public void OnGetPurchasedItems(ItemInstance[] itemInstanceList)
	{
		RefreshUseItemList(itemInstanceList);
	}
	
	private void RefreshUseItemList(ItemInstance[] itemInstanceList)
	{
		
		if(itemInstanceList.Length > 0)
		{
			int counter = 0;
			for(int i=0; i<itemInstanceList.Length; i++)
			{
				if(counter < 3)
				{
					if(itemInstanceList[i].GetRemainingUses() > 0)
					{
						PopulateButtonTextWithItemInstance(useItemInstanceButtons[counter], useItemInstanceButtonTexts[counter], useItemInstanceEvents[counter], itemInstanceList[i]);
						counter++;
					}
				}
			}
			if(counter < 3)
			{
				for(int i= counter; i<3; i++)
				{
					useItemInstanceButtons[i].gameObject.SetActive(false);
				}
			}
		}
		else
		{
			for(int i=0; i<3; i++)
			{
				useItemInstanceButtons[i].gameObject.SetActive(false);
			}
		}
	}
	
	private void PopulateButtonTextWithItemInstance(Button button, Text buttonText, EventTrigger eventTrigger, ItemInstance currentItem)
	{
		if(currentItem.GetRemainingUses() > 0)
		{
			buttonText.text = "Use " + currentItem.GetIdentifier() + " [" + currentItem.GetRemainingUses() + "]";
			long instanceId = currentItem.GetInstanceId();
			eventTrigger.triggers.Clear ();
			EventTrigger.Entry pointerEnterEntry = new EventTrigger.Entry();
			pointerEnterEntry.eventID = EventTriggerType.PointerClick;
			pointerEnterEntry.callback = new EventTrigger.TriggerEvent();
			pointerEnterEntry.callback.AddListener(delegate{UseItemInstance(instanceId.ToString());});
			eventTrigger.triggers.Add (pointerEnterEntry);
			button.interactable = true;
		}
		else
		{
			buttonText.text = currentItem.GetIdentifier() + " [0]";
			button.interactable = false;
		}
		button.gameObject.SetActive(true); 
	}
	
	public void PurchaseItems()
	{
		if(itemIdInput.text.Split(',').Length > 1)
		{
			Kongregate.PurchaseItems(itemIdInput.text.Split(','), OnItemPurchaseResult);
		}
		else
		{
			Kongregate.PurchaseItem(itemIdInput.text, OnItemPurchaseResult);
		}
	}
	
	public void UseItemInstance(string instanceId)
	{
		Kongregate.UseItemInstance(instanceId, OnUseItemInstanceResult);
	}
	
	public void OnItemPurchaseResult(bool success)
	{
		if(success)
		{
			GetPurchasedItems();
			//DisplayItemPurchaseSuccess();
		}
		else
		{
			//DisplayItemPurchaseFailed();
		}
	}
	
	public void OnUseItemInstanceResult(bool success)
	{
		if(success)
		{
			GetPurchasedItems();
			//DisplayUseItemSuccess();
		}
		else
		{
			//DisplayUseItemFailed();
		}
	}

	public void RefreshUserInfo()
	{
		Kongregate.RefreshUserInfo(OnUserInfoReceived);
	}
	
	public void OnUserInfoReceived()
	{
		userDataText.text = Kongregate.GetUserId () + ", " + Kongregate.GetUserName () + ", " + Kongregate.GetGameAuthToken ();
	}
	
	public void ClearLogs()
	{
		Kongregate.ClearLog();
	}
}
