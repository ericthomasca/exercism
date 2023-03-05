pub fn production_rate_per_hour(speed: u8) -> f64 {
    if (0..=4).contains(&speed) {
        speed as f64 * 221.0
    } else if (5..=8).contains(&speed) {
        speed as f64 * 221.0 * 0.9
    } else if (9..=10).contains(&speed) {
        speed as f64 * 221.0 * 0.77
    } else {
        0.0
    }
}

pub fn working_items_per_minute(speed: u8) -> u32 {
    let cars_per_hour = production_rate_per_hour(speed);
    (cars_per_hour / 60.0) as u32
}
