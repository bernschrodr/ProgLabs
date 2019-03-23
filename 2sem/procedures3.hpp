#include <string>

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

class queue
{

  private:
    std::string *que;
    unsigned int size;
    unsigned int in = 0;
    unsigned int out = 0;

  public:
    queue();
    queue(int size);
    queue(std::string);

    void push(std::string str);
    std::string pop();
    const std::string getFirst();
    const std::string getLast();
    const int getLength();
    const void prnt();
};
