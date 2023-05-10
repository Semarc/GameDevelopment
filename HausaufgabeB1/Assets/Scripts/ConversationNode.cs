using UnityEngine;

public class ConversationNode : ScriptableObject
{
	public ConversationAnswer[] conversationAnswers { get; private set; }
	public string Question { get; private set; }
	public GameLocation GameLocation { get; private set; }

	public ConversationNode(string Question, GameLocation GameLocation, params ConversationAnswer[] answers)
	{
		this.Question = Question;
		this.GameLocation = GameLocation;
		conversationAnswers = answers;
	}

	public ConversationNode SelectAnswer(int Selected)
	{
		return conversationAnswers[Selected].NextNode;
	}
}