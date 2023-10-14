use blog_domain::traits::data_access_services::blog_das::BlogDas;
use diesel::{Connection, PgConnection};

pub struct BlogDasImpl {
    database: PgConnection,
}

impl BlogDasImpl {
    pub fn new(connection_string: String) -> BlogDasImpl {
        BlogDasImpl {
            database: PgConnection::establish(&connection_string).unwrap_or_else(|error| {
                panic!("Error connecting to {}: {}", connection_string, error)
            }),
        }
    }
}

// Impl trait BlogDas

impl BlogDas for BlogDasImpl {
    fn get_blog(
        &self,
        id: i32,
    ) -> Result<blog_domain::entities::blog::Blog, Box<dyn std::error::Error>> {
        println!("get_blog");
        todo!()
    }

    fn get_blogs(
        &self,
    ) -> Result<Vec<blog_domain::entities::blog::Blog>, Box<dyn std::error::Error>> {
        todo!()
    }

    fn create_blog(
        &self,
        blog: &blog_domain::entities::blog::Blog,
    ) -> Result<blog_domain::entities::blog::Blog, Box<dyn std::error::Error>> {
        todo!()
    }

    fn update_blog(
        &self,
        blog: &blog_domain::entities::blog::Blog,
    ) -> Result<blog_domain::entities::blog::Blog, Box<dyn std::error::Error>> {
        todo!()
    }

    fn delete_blog(&self, id: i32) -> Result<(), Box<dyn std::error::Error>> {
        todo!()
    }
}
