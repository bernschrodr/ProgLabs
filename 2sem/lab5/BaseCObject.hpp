#ifndef BASE_C_OBJECT
#define BASE_C_OBJECT

class BaseCObject {
public:
// Имя класса (типа данных).
    virtual const char* classname() = 0;
// Размер занимаемой памяти.
    virtual unsigned int size() = 0;
};

#endif
