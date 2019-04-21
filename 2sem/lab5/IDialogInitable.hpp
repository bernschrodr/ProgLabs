#ifndef I_DIALOG_INITIABLE
#define I_DIALOG_INITIABLE

class IDialogInitiable {

public:

    // Задать параметры объекта с помощью диалога с пользователем.
    virtual void initFromDialog() = 0;
};

#endif
