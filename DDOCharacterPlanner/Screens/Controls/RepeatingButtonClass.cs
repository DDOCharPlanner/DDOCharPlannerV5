using System;
using System.Windows.Forms;

namespace DDOCharacterPlanner.Screens.Controls
	{
	/// <summary>
	/// A repeating button class, allows the user to hold down a button and have it auto-click.
	/// When the mouse is held down on the button it will first wait for FirstDelay milliseconds,
	/// then auto-press the button every LoSpeedWait milliseconds until LoHiChangeTime milliseconds,
	/// then auto-press the button every HiSpeedWait milliseconds
	/// </summary>
	public class RepeatingButtonClass : Button
		{
		#region Member Variables
		private int FirstDelay; 		// The delay before first repeat in milliseconds
		private int LowSpeedWait;		// The delay in milliseconds between repeats before LoHiChangeTime
		private int HighSpeedWait;		// The delay in milliseconds between repeats after LoHiChangeTime
		private int LowHighChangeTime;	// The changeover time between slow repeats and fast repeats in milliseconds
		private Timer InternalTimer;	// The timer
		#endregion

		#region Constructors
		/// <summary>
		/// Initialize the repeating button (default constructor needed for drag/drop to forms)
		/// </summary>
		public RepeatingButtonClass()
			{
			FirstDelay = 500;
			LowSpeedWait = 300;
			HighSpeedWait = 100;
			LowHighChangeTime = 2000;

			InternalTimer = new Timer();
			InternalTimer.Interval = FirstDelay;
			InternalTimer.Tick += new EventHandler(InternalTimerTick);
			MouseDown += new MouseEventHandler(RepeatingButtonMouseDown);
			MouseUp += new MouseEventHandler(RepeatingButtonMouseUp);
			}

		/// <summary>
		/// Initialize the repeating button
		/// </summary>
		public RepeatingButtonClass(int firstDelay = 500, int lowSpeedWait = 300, int highSpeedWait = 100, int lowHighChangeTime = 2000)
			{
			FirstDelay = firstDelay;
			LowSpeedWait = lowSpeedWait;
			HighSpeedWait = highSpeedWait;
			LowHighChangeTime = lowHighChangeTime;

			InternalTimer = new Timer();
			InternalTimer.Interval = FirstDelay;
			InternalTimer.Tick += new EventHandler(InternalTimerTick);
			MouseDown += new MouseEventHandler(RepeatingButtonMouseDown);
			MouseUp += new MouseEventHandler(RepeatingButtonMouseUp);
			}
		#endregion

		#region Public Methods
		/// <summary>
		/// Allows us to set the delay parameters if the default constructor was used
		/// </summary>
		/// <param name="firstDelay"></param>
		/// <param name="lowSpeedWait"></param>
		/// <param name="highSpeedWait"></param>
		/// <param name="lowHighChangeTime"></param>
		public void SetRepeatDelays(int firstDelay = 500, int lowSpeedWait = 300, int highSpeedWait = 100, int lowHighChangeTime = 2000)
			{
			FirstDelay = firstDelay;
			LowSpeedWait = lowSpeedWait;
			HighSpeedWait = highSpeedWait;
			LowHighChangeTime = lowHighChangeTime;
			}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Mouse Down Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RepeatingButtonMouseDown(object sender, MouseEventArgs e)
			{
			InternalTimer.Tag = DateTime.Now;
			InternalTimer.Start();
			}

		/// <summary>
		/// Mouse Up Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RepeatingButtonMouseUp(object sender, MouseEventArgs e)
			{
			InternalTimer.Stop();
			InternalTimer.Interval = FirstDelay;
			}

		/// <summary>
		/// Timer event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InternalTimerTick(object sender, EventArgs e)
			{
			//auto-press the button
			OnClick(e);
			TimeSpan elapsed = DateTime.Now - ((DateTime)InternalTimer.Tag);
			if (elapsed.TotalMilliseconds < LowHighChangeTime)
				InternalTimer.Interval = LowSpeedWait;
			else
				InternalTimer.Interval = HighSpeedWait;
			}
		}
		#endregion
	}
