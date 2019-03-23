#include <iostream>
#include "procedures3.hpp"

int main()
{
    //COMPLEX nums
    std::cout << "COMPLEX" << std::endl;

    comp a(10, 24);
    comp b(11, 23);
    a.sum(b);
    a.prnt();
    a.multiply(b);
    a.prnt();
    b.multiply(2);
    b.prnt();
    std::cout << b.abs() << std::endl;

    //QUEUE of strings
    std::cout << std::endl
              << "QUEUE" << std::endl;

    queue first;
    queue second(12);
    queue third("max");

    std::cout << "first queue length: " << first.getLength() << std::endl;
    std::cout << "second queue length: " << second.getLength() << std::endl;
    std::cout << "second queue length: " << third.getLength() << std::endl;
    second.push("First string");
    second.push("Second string");
    //MaxLength error
    second.push("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

    std::cout << "first element: " << second.getFirst() << std::endl;
    std::cout << "last element: " << second.getLast() << std::endl;

    std::cout << "Print all elements of queue:" << std::endl;
    second.prnt();

    second.pop();
    std::cout << "first element after pop: " << second.getFirst() << std::endl;

    second.pop();
    second.pop();
    second.getLast();
    second.getLast();
    second.getLast();
    second.getLast();

    //queue is empty

    return 0;
}