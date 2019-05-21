template <typename T, typename Pred>
bool all_of(T &collection, Pred pred)
{
    for (typename T::iterator it = collection.begin(); it != collection.end(); it++)
    {
        if (!pred(*it))
            return false;
    }
    return true;
}

template <typename T, typename Pred>
bool is_partitioned(T &collection, Pred pred)
{
    bool flag = false;
    for (typename T::iterator it = ++collection.begin(); it != collection.end(); it++)
    {
        if (!flag)
        {
            if (pred(*it) != pred(*prev(it)))
            {
                flag = true;
            }
        }
        else
        {
            if (next(it) != collection.end() && pred(*it) != pred(*next(it)))
                return false;
        }
    }
    return true;
}

template <class T>
typename T::iterator find_backward(T &collection, typename T::value_type val)
{
    for (typename T::iterator it = --collection.end() ; it >= collection.begin(); it--)
    {
        if ((*it == val))
            return it;
    }

    return collection.end();
}