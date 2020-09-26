using System;
using System.Collections.ObjectModel;

namespace Sbn.FramWork.Drawing.Core.Utilities
{
	public static class History<State> where State : ICloneable
	{
		private static int _cursor = 0;

		private static Collection<State> _history = new Collection<State>();

		public static bool IsActive = true;

		private static int _buffer = 50;

		public static int Buffer
		{
			get
			{
				return History<State>._buffer;
			}
			set
			{
				History<State>._buffer = value;
				if (History<State>._buffer <= 10)
				{
					History<State>._buffer = 10;
				}
			}
		}

		public static bool IsAtStart()
		{
			return History<State>._cursor == 0 || History<State>._history.Count == 0;
		}

		public static bool IsAtEnd()
		{
			return History<State>._cursor == History<State>._history.Count - 1 || History<State>._history.Count == 0;
		}

		public static void Delete()
		{
			History<State>._history.Clear();
			History<State>._cursor = 0;
		}

		public static void Memorize(State state)
		{
			if (History<State>.IsActive)
			{
				History<State>._history.Add((State)((object)state.Clone()));
				History<State>._cursor = History<State>._history.Count - 1;
			}
		}

		public static State Undo()
		{
			if (History<State>._cursor > 0)
			{
				History<State>._cursor--;
			}
			State state = History<State>._history[History<State>._cursor];
			return (State)((object)state.Clone());
		}

		public static State Redo()
		{
			if (History<State>._cursor < History<State>._history.Count - 1)
			{
				History<State>._cursor++;
			}
			State state = History<State>._history[History<State>._cursor];
			return (State)((object)state.Clone());
		}
	}
}
