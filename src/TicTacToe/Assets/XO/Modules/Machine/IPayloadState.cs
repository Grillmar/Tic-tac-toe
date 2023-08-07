namespace XO.Modules.Machine
{
  public interface IPayloadState<in TPayload> : IExitableState
  {
    void Enter(TPayload payload);
  }
}