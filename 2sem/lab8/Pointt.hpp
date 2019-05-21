#include <cmath>
#include <string>

class Pointt
{

public:
    double x, y;

    Pointt(double x, double y) : x(x), y(y) {}

    double length()
    {
        return sqrt(x * x + y * y);
    }

    bool operator==(const Pointt &b)
    {
        return x == b.x && y == b.y;
    }

    std::string to_str()
    {
        return "x: " + std::to_string(x) + "    y: " + std::to_string(y);
    }
};