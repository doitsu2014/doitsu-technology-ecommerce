use blog_domain::traits::data_access_services::blog_das::BlogDas;
use blog_infrastructure::{data_access_services::blog_das::BlogDasImpl, initialize_db};
use dotenvy::dotenv;
use std::env;

#[tokio::main]
async fn main() {
    println!("Hello, world!");
    dotenv().ok();

    let database_url = env::var("DATABASE_URL").expect("DATABASE_URL must be set");
    initialize_db(database_url);

    let database_url = env::var("DATABASE_URL").expect("DATABASE_URL must be set");
    let blog_das = BlogDasImpl::new(database_url.into());
    let b = blog_das.get_blog(1);
}
