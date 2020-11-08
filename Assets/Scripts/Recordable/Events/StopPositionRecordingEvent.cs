namespace Assets.Scripts.Recordable.Events {
    public class StopPositionRecordingEvent : RecordableEvent {

        public PositionRecorder PositionRecorder { get; set; }

        public override void HandleForward () {
            PositionRecorder.StopPlayback ();
        }

        public override void HandleBackward () {
            PositionRecorder.StartPlaybackBackward ();
        }
    }
}
