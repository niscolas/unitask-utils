namespace niscolas.UnityUtils.UniTask
{
    public class DelayedOnEnableEvent : BaseDelayedMonoEvent
    {
        private void OnEnable()
        {
            Raise();
        }
    }
}