using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
	[SerializeField] private List<Button> ConversationButtons;
	[SerializeField] private TMP_Text ConversationText;
	[SerializeField] private Image GameLocationImage;
	[SerializeField] private Sprite[] BackgroundImages;

	ConversationNode CurrentConversationNode;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < ConversationButtons.Count; i++)
		{
			int i1 = i;
			ConversationButtons[i].onClick.AddListener(() => OnConversationClick(i1));
		}
	}
	public void OnConversationClick(int ConversationOption)
	{
		CurrentConversationNode = CurrentConversationNode.SelectAnswer(ConversationOption);
		ConversationText.text = CurrentConversationNode.Question;
		GameLocationImage.sprite = CurrentConversationNode.GameLocation.BackgroundImage;
	}



	public ConversationNode ConversationTreeStart()
	{
		ConversationNode StartNode = new("SampleQuestion", new GameLocation(backgroundImages[0]), );



			return StartNode;
	}


}