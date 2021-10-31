namespace niscolas.UnityUtils.Extras
{
    public class DelayedOnEnableEvent : BaseDelayedMonoEvent
    {
        private void OnEnable()
        {
            Raise().Forget();
        }
    }
}