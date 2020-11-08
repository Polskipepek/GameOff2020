using Assets.Scripts.Recordable;

namespace Assets.Scripts.Player {
    public class Player : TimelineActor {

        public bool xdddd = false;
        private PositionRecorder PositionRecorder => GetComponent<PositionRecorder> ();
        private void Start () {
            PositionRecorder.StartRecording ();
        }
        private void OnDisable () {
            PositionRecorder.StopRecording ();
            xdddd = true;
        }
        private void OnEnable () {
            if (xdddd)
                Timeline.StartPlaybackBackward ();
            xdddd = false;
        }
    }
}
