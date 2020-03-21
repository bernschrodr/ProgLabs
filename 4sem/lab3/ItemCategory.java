public enum ItemCategory {
    FOOD(2),
    PRINT(3),
    DRESS(4),
    GENERAL(1);

    private int category;

    ItemCategory(int num){
        category = num;
    }

    int getCategory(){
        return category;
    }
}