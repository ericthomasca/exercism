package cars

// CalculateWorkingCarsPerHour calculates how many working cars are
// produced by the assembly line every hour.
func CalculateWorkingCarsPerHour(productionRate int, successRate float64) float64 {
	return float64(productionRate) * successRate / 100.0
}

// CalculateWorkingCarsPerMinute calculates how many working cars are
// produced by the assembly line every minute.
func CalculateWorkingCarsPerMinute(productionRate int, successRate float64) int {
	working_cars_per_hour := CalculateWorkingCarsPerHour(productionRate, successRate)
	return int(working_cars_per_hour / 60.0)
}

// CalculateCost works out the cost of producing the given number of cars.
func CalculateCost(carsCount int) uint {
	car_groups :=int(carsCount / 10.0)
	car_singles := carsCount - (car_groups * 10)
	return uint(car_groups * 95000) + uint(car_singles * 10000)
}
