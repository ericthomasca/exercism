// Package weather provides the current weather.
package weather

// CurrentCondition is a description of current weather condition.
var CurrentCondition string
// CurrentLocation is the current city of the current weather condition.
var CurrentLocation string

// Forecast return a string with current location and current condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
