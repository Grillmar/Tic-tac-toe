namespace XO.Modules.Window.Windows
{
  public class PayloadedWindow<TPayload> : BaseWindow
  {
    public virtual void Set(TPayload payload) { }
  }
}