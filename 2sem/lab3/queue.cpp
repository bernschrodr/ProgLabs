#include "queue.hpp"
#include <cmath>
#include <iostream>
#include <string>

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
        reset();
        return "";
    }
}

void queue::reset()
{
    out = 0;
    in = 0;
    for (int i = 0; i < size; i++)
        que[i] = "";
}

const std::string queue::getFirst()
{
    if (out >= 0 && in != out)
        return que[out];
    else
    {
        return "";
    }
}

const std::string queue::getLast()
{
    if (in > 0 && in != out)
        return que[in - 1];
    else
    {

        return "";
    }
}

const int queue::getLength()
{
    return size;
}

const void queue::prnt()
{
    for (unsigned int i = out; i < in; i++)
        std::cout << que[i] << std::endl;
}