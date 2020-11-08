using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Recordable {
    [RequireComponent (typeof (Timeline))]
    public class TimelineActor : MonoBehaviour {
        public Timeline Timeline => GetComponent<Timeline> ();
        public TimelineState TimelineState => Timeline.TimelineState;
    }
}
