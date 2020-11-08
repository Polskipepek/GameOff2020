using Assets.Scripts.Enums;
using Assets.Scripts.Recordable.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Recordable {
    public class Timeline : MonoBehaviour {
        public TimelineState TimelineState { get; private set; } = TimelineState.None;
        private List<TimelineEvent> _timelineEvents = new List<TimelineEvent> ();
        private float _timeToNextEvent;
        private int _currentEvent;

        public void StartPlaybackForward () {
            _currentEvent = 0;
            _timeToNextEvent = _timelineEvents[0].Time;
            TimelineState = TimelineState.PlaybackForward;
        }

        public void StartPlaybackBackward () {
            _currentEvent = _timelineEvents.Count - 1;
            _timeToNextEvent = Time.unscaledTime - _timelineEvents[_timelineEvents.Count - 1].Time;
            TimelineState = TimelineState.PlaybackBackward;
        }

        public void AddEvent (RecordableEvent recordableEvent) {
            _timelineEvents.Add (new TimelineEvent { RecordableEvent = recordableEvent, Time = Time.unscaledTime });
        }

        private void FixedUpdate () {
            _timeToNextEvent -= Time.fixedUnscaledDeltaTime;
            if (_timeToNextEvent <= 0) {
                switch (TimelineState) {
                    case TimelineState.None:
                        break;
                    case TimelineState.PlaybackForward:
                        _timelineEvents[_currentEvent].RecordableEvent.HandleForward ();
                        if (_currentEvent < _timelineEvents.Count - 1) {
                            _timeToNextEvent = _timelineEvents[_currentEvent + 1].Time - _timelineEvents[_currentEvent].Time;
                            _currentEvent++;
                        }
                        break;
                    case TimelineState.PlaybackBackward:
                        _timelineEvents[_currentEvent].RecordableEvent.HandleBackward ();
                        if (_currentEvent > 0) {
                            _timeToNextEvent = _timelineEvents[_currentEvent].Time - _timelineEvents[_currentEvent - 1].Time;
                            _currentEvent--;
                        }
                        break;
                }
            }
        }
    }
}
