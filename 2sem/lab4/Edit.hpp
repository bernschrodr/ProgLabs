#include <string>
using namespace std;

class Coordinate
{
public:
  float x, y;
  Coordinate() : x(0), y(0){};
  Coordinate(float x, float y) : x(x), y(y){};
  bool equal(Coordinate &obj);
};

class Edit
{
private:
  /* data */
public:
  Coordinate *coord;
  string text = "";
  string history = "";
  bool save_flag = false;
  bool autofill_flag = false;

  Edit();
  Edit(const float &x, const float &y);
  Edit(const float &x, const float &y, const string &str);
  Edit(const float &x, const float &y, const bool &save_flag);
  Edit(const float &x, const float &y, const string &str, const bool &save_flag);
  Edit(const float &x, const float &y, const bool &save_flag, const bool &autofill_flag);
  Edit(const float &x, const float &y, const string &str, const bool &save_flag, const bool &autofill_flag);
  Edit(const Edit &obj);

  ~Edit();

  bool equal(Edit &obj);
  Coordinate GetCoord();
  void SetCoord(const float &x, const float &y);
  void Input(const string &str);
  void SaveFlag(const bool &flag);
  void AutoFill_Flag(const bool &flag);
  void AutoFill(const string &str);
};

