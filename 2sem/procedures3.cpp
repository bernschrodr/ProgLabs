#include "procedures3.hpp"
#include <cmath>
#include <iostream>
#include <string>

//COMPLEX NUM
comp::comp() : z(2), zi(3){};

comp::comp(float z, float zi) : z(z), zi(zi){};

comp::comp(const comp &first)
{
    this->z = first.z;
    this->zi = first.zi;
}

void comp::sum(comp first)
{
    this->z += first.z;
    this->zi += first.zi;
}

void comp::multiply(float num)
{
    this->z *= num;
    this->zi *= num;
}

void comp::multiply(comp &second)
{
    this->z = second.z * second.zi - this->z * this->zi;
    this->zi = second.z * this->zi + second.zi * this->z;
}

const float comp::abs()
{
    return (sqrt(pow(this->z, 2) + pow(this->zi, 2)));
}

const void comp::prnt()
{
    std::cout << this->z;
    if (this->zi >= 0)
        std::cout << "+";
    std::cout << this->zi << "i" << std::endl;
    ;
}

//QUEUE
queue::queue() : size(100)
{
    que = new std::string[100];
};

queue::queue(int size) : size(size)
{
    que = new std::string[size];
};

//если передать аргументом строку max значение очереди будет равно значению 5000
queue::queue(std::string str)
{
    if (str == "max")
    {
        this->size = 5000;
        que = new std::string[size];
    }
    return;
}

void queue::push(std::string str)
{

    if (str.length() > 255)
    {
        std::cout << "String length more than 255" << std::endl;
        return;
    }

    if (in == size - 1)
    {
        std::cout << "queue is full" << std::endl;
        return;
    }

    que[in++] = str;
    return;
}

std::string queue::pop()
{
    if (out != in)
        return que[out++];
    else
    {
        std::cout << "queue is empty" << std::endl;
        return "";
    }
}

const std::string queue::getFirst()
{
    if (out > 0 && in != out)
        return que[out - 1];
    else
    {
        std::cout << "queue is empty" << std::endl;
        return "";
    }
}

const std::string queue::getLast()
{
    if (in > 0 && in != out)
        return que[in - 1];
    else
    {
        std::cout << "queue is empty" << std::endl;
        return "";
    }
}

const int queue::getLength()
{
    return size;
}

const void queue::prnt()
{
    for (unsigned int i = 0; i < in; i++)
        std::cout << que[i] << std::endl;
}