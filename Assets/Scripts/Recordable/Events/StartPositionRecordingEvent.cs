namespace Assets.Scripts.Recordable.Events {
    public class StartPositionRecordingEvent : RecordableEvent {
        public PositionRecorder PositionRecorder { get; set; }
        public override void HandleForward () {
            PositionRecorder.StartPlaybackForward ();
        }

        public override void HandleBackward () {
            PositionRecorder.StopPlayback ();
        }
    }
}
