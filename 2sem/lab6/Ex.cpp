#include "Ex.hpp"
#include <iostream>

using namespace std;

Ex::Ex(int index, int size){
    if(index < 0)
        dataState = NegativeArrayIndexException;
    if(index > size)
        dataState = ArrayIndexOutOfBoundsException;
    }