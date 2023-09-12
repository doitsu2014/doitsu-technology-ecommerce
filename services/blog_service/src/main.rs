use std::env;
use blog_infrastructure::initialize_db;
use dotenvy::dotenv;

#[tokio::main]
async fn main() {
    println!("Hello, world!");
    dotenv().ok();

    let database_url = env::var("DATABASE_URL").expect("DATABASE_URL must be set");
    initialize_db(database_url);
}
