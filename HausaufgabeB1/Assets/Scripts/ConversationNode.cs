using System;
using System.Collections.Generic;

using UnityEngine;

public class ConversationNode
{
	public List<ConversationAnswer> conversationAnswers { get; set; } = new();
	public string Question { get; private set; }
	public GameLocation GameLocation { get; private set; }

	public ConversationNode(string Question, GameLocation GameLocation)
	{
		this.Question = Question;
		this.GameLocation = GameLocation;
	}

	public ConversationNode SelectAnswer(int Selected)
	{
		conversationAnswers[Selected].SelectFunc();
		return conversationAnswers[Selected].NextNode;
	}
}