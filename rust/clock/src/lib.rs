use std::fmt;

pub struct Clock {
    hours: i32,
    minutes: i32
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        
        
        Clock { hours, minutes }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        let added_minutes = self.minutes + minutes;
        let hours = self.hours;
        let added_hours: i32;
        
        if added_minutes > 59 {
            added_minutes = added_minutes - 60;
            added_hours = self.hours + 1;
        } else if added_hours > 24 {
            hours -= 24;
        }

        Clock { hours: self.hours, minutes: self.minutes }
    }

}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "({}:{})", self.hours, self.minutes)
    }
}
