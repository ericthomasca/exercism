package blackjack

// ParseCard returns the integer value of a card following blackjack ruleset.
func ParseCard(card string) int {
	switch {
	case card == "ace":
		return 11
	case card == "two":
		return 2
	case card == "three":
		return 3
	case card == "four":
		return 4
	case card == "five":
		return 5
	case card == "six":
		return 6
	case card == "seven":
		return 7
	case card == "eight":
		return 8
	case card == "nine":
		return 9
	case card == "ten" || card == "jack" || card == "queen" || card == "king":
		return 10
	default:
		return 0
	}
}

// FirstTurn returns the decision for the first turn, given two cards of the
// player and one card of the dealer.
func FirstTurn(card1, card2, dealerCard string) string {
	card1_val := ParseCard(card1)
	card2_val := ParseCard(card2)
	dealerCard_val := ParseCard(dealerCard)
	hand_val := card1_val + card2_val
	first_turn := ""

	switch{
	case card1 == "ace" && card2 == "ace":
		first_turn += "P"
	case hand_val == 21 && dealerCard_val != 11 && dealerCard_val != 10:
		first_turn += "W"
	case hand_val == 21 && dealerCard_val <= 11:
		first_turn += "S"
	case hand_val >= 17 && hand_val <= 20:
		first_turn += "S"
	case hand_val >= 12 && hand_val <= 16 && dealerCard_val < 7:
		first_turn += "S"
	case hand_val >= 12 && hand_val <= 16 && dealerCard_val >= 7:
		first_turn += "H"
	case hand_val <= 11:
		first_turn += "H"
	default:
		first_turn += ""
	}

	return first_turn
}
