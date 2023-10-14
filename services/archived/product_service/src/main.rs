use std::env;

use dotenvy::dotenv;
use product_infrastructure::initialize_db;

#[tokio::main]
async fn main() {
    println!("Hello, world!");
    dotenv().ok();

    let database_url = env::var("DATABASE_URL").expect("DATABASE_URL must be set");
    initialize_db(database_url);

}
