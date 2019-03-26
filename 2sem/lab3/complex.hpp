class comp
{

private:
  float z, zi;

public:
  comp();
  comp(float z, float zi);
  comp(const comp &first);
  void sum(comp first);
  void multiply(float num);
  void multiply(comp &second);
  const float abs();
  const void prnt();
};