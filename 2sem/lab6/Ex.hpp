#include <exception>

using namespace std;

enum state
    {
        ArrayIndexOutOfBoundsException,
        NegativeArrayIndexException
    };

class Ex : public exception
{
  public:

    Ex(int index, int size);

    state dataState;
};