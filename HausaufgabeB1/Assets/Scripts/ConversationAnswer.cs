using UnityEditor;

using UnityEngine;

public class ConversationAnswer : ScriptableObject
{
	public ConversationNode NextNode { get; private set; }
	public string Answer { get; private set; }
}