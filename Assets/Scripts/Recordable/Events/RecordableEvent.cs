namespace Assets.Scripts.Recordable.Events {
    public abstract class RecordableEvent {

        public abstract void HandleForward ();

        public abstract void HandleBackward ();
    }
}
