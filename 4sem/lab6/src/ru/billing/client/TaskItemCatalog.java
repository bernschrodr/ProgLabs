package ru.billing.client;
import ru.billing.stocklist.GenericItem;
import ru.billing.stocklist.ItemCategory;
import ru.billing.stocklist.PriceCategory;
import ru.billing.stocklist.Pair;

import java.util.HashMap;
import java.util.HashSet;


public class TaskItemCatalog {
    private HashMap<Integer, GenericItem> catalog = new HashMap<Integer, GenericItem>();
    private HashMap<Pair<ItemCategory, Boolean>, HashSet<GenericItem>> catalogByCategoryAndPrice = new HashMap<Pair<ItemCategory, Boolean>, HashSet<GenericItem>>();

    public void add(GenericItem item) {
        catalog.put(item.getID(), item);
        Pair<ItemCategory, Boolean> pair = new Pair<ItemCategory, Boolean>(item.getCategory(), isExpensive(item.getPriceCategory()));
        var set = catalogByCategoryAndPrice.get(pair);
        if(set != null) {
            set.add(item);
        }else {
            var newSet = new HashSet<GenericItem>();
            newSet.add(item);
            catalogByCategoryAndPrice.put(pair,newSet);
        }
    }


    public GenericItem findById(int id) {
        return catalog.get(id);
    }

    public void removeById(int id) {
        catalog.remove(id);
    }

    public HashSet<GenericItem> findByCategoryAndPrice(ItemCategory category, boolean isExpensive) {
        Pair<ItemCategory, Boolean> pair = new Pair<ItemCategory, Boolean>(category, isExpensive);
        var set = catalogByCategoryAndPrice.get(pair);
        return set;
}

    public boolean isExpensive(PriceCategory category) {
        if (category == PriceCategory.CHEAP) {
            return false;
        }
        if (category == PriceCategory.EXPENSIVE) {
            return true;
        }
        return false;
    }

}
