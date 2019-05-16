using System;
using System.Drawing;
using System.Timers;

namespace ConsoleApp1
{
    public class BoardModel : IDisposable
    {
        private Random randomGen = new Random();
        public BoardModel()
        {
            SetTimer();
        }
        public enum State
        {
            Blank,
            Bomb
        }
        public delegate void BoardAction(Point p, State state);

        public event BoardAction BoardChangesEvent;

        #region TimerDetails

        private System.Timers.Timer _aTimer;
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            _aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Point p = new Point(randomGen.Next(), randomGen.Next());
            BoardChangesEvent?.Invoke(p, State.Bomb);
        }

        #endregion


        public void Dispose()
        {
            _aTimer.Stop();
            _aTimer.Dispose();
            _aTimer?.Dispose();
        }
    }
}