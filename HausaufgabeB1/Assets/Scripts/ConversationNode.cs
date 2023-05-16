using System;
using System.Collections.Generic;

using UnityEngine;

public class ConversationNode : ScriptableObject
{
	public List<ConversationAnswer> conversationAnswers { get; set; }
	public string Question { get; private set; }
	public GameLocation GameLocation { get; private set; }

	public ConversationNode(string Question, GameLocation GameLocation)
	{
		this.Question = Question;
		this.GameLocation = GameLocation;
	}

	public ConversationNode SelectAnswer(int Selected)
	{
		return conversationAnswers[Selected].NextNode;
	}
}