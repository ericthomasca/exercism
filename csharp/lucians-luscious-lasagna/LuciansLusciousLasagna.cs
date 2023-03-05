class Lasagna
{
    public int ExpectedMinutesInOven() {
        return 40;
    }

    public int RemainingMinutesInOven(int cookingTime) {
        int expectedTime = ExpectedMinutesInOven();
        return expectedTime - cookingTime;
    }

    public int PreparationTimeInMinutes(int layers) {
        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int cookingTime) {
        int layerPrepTime = PreparationTimeInMinutes(layers);
        return layerPrepTime + cookingTime;
    }
}
