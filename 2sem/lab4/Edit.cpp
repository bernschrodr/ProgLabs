using namespace std;
#include "Edit.hpp"

Edit::Edit()
{
    coord = new Coordinate();
}

Edit::Edit(const float &x, const float &y)
{
    coord = new Coordinate(x, y);
}

Edit::Edit(const float &x, const float &y, const string &str)
{
    coord = new Coordinate(x, y);
    this->history += str + "\n";
    this->text = str;
}

Edit::Edit(const float &x, const float &y, const bool &save_flag)
{
    coord = new Coordinate(x, y);
    this->save_flag = save_flag;
}

Edit::Edit(const float &x, const float &y, const string &str, const bool &save_flag)
{
    coord = new Coordinate(x, y);
    this->save_flag = save_flag;
    this->history += str + "\n";
    this->text = str;
}

Edit::Edit(const float &x, const float &y, const bool &save_flag, const bool &autofill_flag)
{
    coord = new Coordinate(x, y);
    this->save_flag = save_flag;
    this->autofill_flag = autofill_flag;
}

Edit::Edit(const float &x, const float &y, const string &str, const bool &save_flag, const bool &autofill_flag)
{
    coord = new Coordinate(x, y);
    this->save_flag = save_flag;
    this->autofill_flag = autofill_flag;
    this->history += str + "\n";
    this->text = str;
}

Edit::Edit(const Edit &obj)
{
    this->text = obj.text;
    this->autofill_flag = obj.autofill_flag;
    this->save_flag = obj.save_flag;
    this->coord = obj.coord;
}

Edit::~Edit()
{
}

bool Coordinate::equal(Coordinate &obj)
{
    if (Coordinate::x == obj.x && Coordinate::y == obj.y)
        return true;
    else

        return false;
}

bool Edit::equal(Edit &obj)
{
    if (this->text == this->text && this->autofill_flag == obj.autofill_flag &&
        this->save_flag == obj.save_flag)
        return true;
    else
        return false;
}

Coordinate Edit::GetCoord()
{
    return *this->coord;
};

void Edit::SetCoord(const float &x, const float &y)
{
    coord = new Coordinate(x, y);
};

void Edit::Input(const string &str)
{
    if (save_flag == true)
        history += str + "\n";
    text = str;
};

void Edit::SaveFlag(const bool &flag)
{
    save_flag = flag;
};

void Edit::AutoFill_Flag(const bool &flag)
{
    autofill_flag = flag;
};
void Edit::AutoFill(const string &str)
{
    if (autofill_flag == true)
        text = history + "\n" + str;
    else
        text = str;
};
