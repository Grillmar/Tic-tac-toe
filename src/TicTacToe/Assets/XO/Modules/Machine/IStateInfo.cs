using System;

namespace XO.Modules.Machine
{
  public interface IStateInfo : IUpdateble, IFixedUpdateble
  {
    Type StateType { get; }
    IExitableState State { get; }

    void Exit();
  }
}