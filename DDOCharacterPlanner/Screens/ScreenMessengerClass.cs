using System;
using System.Collections.Generic;
using System.Linq;

namespace DDOCharacterPlanner.Screens
	{
	public class ScreenMessengerClass
		{
		#region Enums
        public enum ChangeList
        {
            RaceChange,
            ClassChange,
            AlignmentChange,
            AbilityChange,
            PastLifeChange,
            SkillChange
        }
		#endregion

		#region Structures
		private struct ListenerEntry
			{
			public UIManagerClass.ChildScreen Screen;
			public ChangeList ChangeType;
			public Action Function;
			}
		#endregion

		#region Member Variables
		private List<ListenerEntry> Listeners;
		#endregion

		#region Constructor
		public ScreenMessengerClass()
			{
			Listeners = new List<ListenerEntry>();
			}
		#endregion

		#region Public Methods
		public void RegisterListen(UIManagerClass.ChildScreen screen, ChangeList change, Action function)
			{
			ListenerEntry newEntry;

			newEntry.Screen = screen;
			newEntry.ChangeType = change;
			newEntry.Function = function;
			Listeners.Add(newEntry);
			}

		public void DeregisterListener(UIManagerClass.ChildScreen screen)
			{
			int i = 0;

			while (i<Listeners.Count)
				{
				if (Listeners[i].Screen == screen)
					Listeners.RemoveAt(i);
				else
					i++;
				}
			}

		public void NotifyChange(UIManagerClass.ChildScreen sender, ChangeList change)
			{
			foreach(ListenerEntry c in Listeners)
				{
				if (c.ChangeType == change && c.Screen != sender)
					{
					c.Function();
					}
				}
			}
		#endregion
		}
	}

