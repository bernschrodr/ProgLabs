namespace lab6{
    public interface IHandler{
        public IHandler SetNext(IHandler handler);
        public object Handle(object request);
    }
}