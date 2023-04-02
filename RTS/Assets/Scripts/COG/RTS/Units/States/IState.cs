namespace COG.States
{
    public interface IState
    {
        public void EnterState();

        public void UpdateState();

        public void ExitState();
    } 
}
