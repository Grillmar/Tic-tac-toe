using System;

namespace XO.Modules.Machine
{
  public abstract class AbstractStateInfo : IStateInfo
  {
    public abstract Type StateType { get; }
    public IExitableState State => _exitable;

    private IExitableState _exitable;
    private IUpdateble _updateble;
    private IFixedUpdateble _fixedUpdateble;


    public void Update() => 
      _updateble?.Update();

    public void FixedUpdate() => 
      _fixedUpdateble?.FixedUpdate();

    public void Exit() => 
      _exitable?.Exit();

    protected void Initialize(IExitableState state)
    {
      _exitable = state;
      _updateble = state as IUpdateble;
      _fixedUpdateble = state as IFixedUpdateble;
    }
  }
}