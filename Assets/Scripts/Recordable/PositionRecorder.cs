using Assets.Scripts.Enums;
using Assets.Scripts.Recordable.Events;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Recordable {

    public class PositionRecorder : TimelineActor {
        public int PlaybackFrame { get; private set; } = 0;

        private List<Vector2> _positions = new List<Vector2> ();

        public RecorderState RecorderState { get; private set; }

        public void StartRecording () {
            StopPlayback ();
            Timeline.AddEvent (new StartPositionRecordingEvent { PositionRecorder = this });
            RecorderState = RecorderState.Recording;
        }

        public void StopRecording () {
            Timeline.AddEvent (new StopPositionRecordingEvent { PositionRecorder = this });
            RecorderState = RecorderState.None;

        }

        public void StartPlaybackForward () {
            PlaybackFrame = 0;
            RecorderState = RecorderState.Playbacking;
        }

        public void StartPlaybackBackward () {
            PlaybackFrame = _positions.Count - 1;
            RecorderState = RecorderState.Playbacking;
        }

        public void StopPlayback () {
            RecorderState = RecorderState.None;
        }

        private void FixedUpdate () {
            if (RecorderState == RecorderState.Recording) {
                RecordPosition ();
            } else if (RecorderState == RecorderState.Playbacking) {
                if (TimelineState == TimelineState.PlaybackForward) {
                    transform.position = _positions[PlaybackFrame];
                    if (PlaybackFrame < _positions.Count - 1) {
                        PlaybackFrame++;
                    } else {
                        StopPlayback ();
                    }
                } else if (TimelineState == TimelineState.PlaybackBackward) {
                    transform.position = _positions[PlaybackFrame];
                    if (PlaybackFrame > 0) {
                        PlaybackFrame--;
                    } else {
                        StopPlayback ();
                    }
                }
            }
        }

        private void RecordPosition () {
            _positions.Add (transform.position);
        }
    }
}