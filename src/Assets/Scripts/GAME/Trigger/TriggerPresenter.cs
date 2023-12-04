namespace Assets.Scripts.GAME.Trigger
{
    public class TriggerPresenter
    {
        readonly ITriggerView _triggerView;

        public TriggerPresenter(ITriggerView triggerView)
        {
            _triggerView = triggerView;
        }
    }
}
