public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (TargetPlayer == null)
            NeedTransit = true;
    }
}