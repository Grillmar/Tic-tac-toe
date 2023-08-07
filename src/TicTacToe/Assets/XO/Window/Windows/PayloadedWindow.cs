namespace XO.Window.Windows
{
  public class PayloadedWindow<TPayload> : BaseWindow
  {
    public virtual void Set(TPayload payload) { }
  }
}