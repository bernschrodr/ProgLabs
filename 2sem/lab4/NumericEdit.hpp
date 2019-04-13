#include "Edit.hpp"
#include <climits>

class NumericEdit : public Edit
{
private:
  /* data */
public:
  float left = __FLT_MIN__;
  float right = __FLT_MAX__;
  int decimals = 36;
  char reaction = 0;

  NumericEdit(const float &x, const float &y);
  NumericEdit(const float &x, const float &y, const string &str);
  NumericEdit(const float &x, const float &y, const string &str, const bool &save_flag);
  NumericEdit(const float &x, const float &y, const string &str, const bool &save_flag, const bool &autofill_flag);
  NumericEdit(const float &x, const float &y, const bool &save_flag);
  NumericEdit(const float &x, const float &y, const bool &save_flag, const bool &autofill_flag);

  NumericEdit(const NumericEdit &obj);
  ~NumericEdit();

  void SetLimit(const float &left, const float &right);
  float GetLeftBorder();
  float GetRightBorder();
  void GetReaction();
  void SetReaction_round();
  void SetReaction_ignore();
  void SetReaction_error();
  int GetDecimals();
  void SetDecimals(int &decimals);
  void Input(const string &str);
  string GetString();
  float GetFloat();
  void error();
  void AutoFill(const string &str);
};