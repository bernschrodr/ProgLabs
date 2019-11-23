namespace lab6
{
    public class AbstractHandler : IHandler
    {
        protected IHandler NextHandler { get; set; }
        public AbstractHandler(IHandler handler)
        {
            SetNext(handler);
        }
        public AbstractHandler() { }
        public IHandler SetNext(IHandler handler)
        {
            NextHandler = handler;
            return handler;
        }

        public virtual object Handle(object request)
        {
            if (NextHandler != null)
            {
                return this.NextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

    }
}