using Assets.Scripts.Recordable.Events;

namespace Assets.Scripts.Recordable {
    public class TimelineEvent {
        public float Time { get; set; }
        public RecordableEvent RecordableEvent { get; set; }
    }
}
