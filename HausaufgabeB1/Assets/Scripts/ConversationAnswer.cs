using System;

using UnityEditor;

using UnityEngine;

public class ConversationAnswer : ScriptableObject
{
	public ConversationAnswer(ConversationNode nextNode, string answer, Func<bool> condition = null, Action selectFunc = null)
	{
		NextNode = nextNode;
		Answer = answer;

		condition ??= () => true;
		Condition = condition;

		selectFunc ??= () => { };
		SelectFunc = selectFunc;
	}

	public ConversationNode NextNode { get; private set; }
	public string Answer { get; private set; }
	public Func<bool> Condition { get; set; }
	public Action SelectFunc { get; set; }
}