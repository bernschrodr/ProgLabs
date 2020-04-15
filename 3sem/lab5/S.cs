public class a
{
  string name;
  public a(string name)
  {
    this.name = name;
  }
}

public class b : a
{
  public b(string name) : base(name)
  {
  }
}