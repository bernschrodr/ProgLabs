#include "Ex.hpp"
#include <iostream>

template <class T>
class Array
{
  public:
    Array() : array(new T[10]){};
    Array(int size) : array(new T[size]), size(size){};

    int size;

    T& operator[] (int index){
        if(index < 0 || size <= index)
            throw Ex(index, size);
        return array[index];
    }

  private:
    T *array;
};

template <class T>
void swap(T *a, T *b)
{
    T c = a;
    b = a;
    a = c;
}
