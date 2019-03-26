#include <iostream>
#include "queue.hpp"
#include "complex.hpp"

class Menu
{

  public:
    // QUEUE

    static void Start();
    static void QueueCreate();
    static void QueueMenu(queue &que);

    static void Push(queue &que);
    static void Pop(queue &que);
    static void GetFirst(queue &que);
    static void GetLast(queue &que);
    static void GetLength(queue &que);
    static void PrntQueue(queue &que);
    

    // COMPLEX

    static void ComplexStart();
    static comp ComplexCreate();
    static void ComplexMenu(comp &complexNum);

    static void Sum(comp &complexNum);
    static void MultiplyNum(comp &complexNum);
    static void MultiplyComplex(comp &complexNum);
    static void GetLength(comp &complexNum);
    static void PrntComplex(comp &complexNum);
    static void WrongInput();
};