use uuid::Uuid;

pub fn insertProduct() -> Uuid {
    return Uuid::new_v4();
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn it_works() {}
}
